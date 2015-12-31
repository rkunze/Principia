﻿#include "ksp_plugin/flight_plan.hpp"

namespace principia {
namespace ksp_plugin {

FlightPlan::FlightPlan(
    not_null<DiscreteTrajectory<Barycentric>*> root,
    Instant const& initial_time,
    Mass const& initial_mass,
    not_null<Ephemeris<Barycentric>*> ephemeris,
    AdaptiveStepSizeIntegrator<
        Ephemeris<Barycentric>::NewtonianMotionEquation> const& integrator)
    : initial_time_(initial_time),
      initial_mass_(initial_mass),
      ephemeris_(ephemeris),
      integrator_(integrator) {
  segments_.emplace(
      root->NewForkWithCopy(root->LowerBound(initial_time).time()));
}

int FlightPlan::size() const {
  return manœuvres_.size();
}

NavigationManœuvre const& FlightPlan::Get(int index) {
  CHECK_LE(0, index);
  CHECK_LT(index, size());
  return manœuvres_[index];
}

bool FlightPlan::Append(Burn burn) {
  auto manœuvre =
      MakeManœuvre(
          std::move(burn),
          manœuvres_.empty() ? initial_mass_ : manœuvres_.back().final_mass());
  if (manœuvre.FitsBetween(
          manœuvres_.empty() ? initial_time_ : manœuvres_.back().final_time(),
          final_time_)) {
    return false;
  } else {
    Append(std::move(manœuvre));
    return true;
  }
}

void FlightPlan::RemoveLast() {
  CHECK(!manœuvres_.empty());
  manœuvres_.pop_back();
  segments_.pop();  // Last coast.
  segments_.pop();  // Last burn.
  ResetLastSegment();
  CoastLastSegment(final_time_);
}

bool FlightPlan::ReplaceLast(Burn burn) {
  CHECK(!manœuvres_.empty());
  auto manœuvre =
      MakeManœuvre(std::move(burn), manœuvres_.back().initial_mass());
  if (manœuvre.FitsBetween(manœuvres_.size() == 1
                               ? initial_time_
                               : manœuvres_[manœuvres_.size() - 2].final_time(),
                           final_time_)) {
    return false;
  } else {
    manœuvres_.pop_back();
    segments_.pop();  // Last coast.
    segments_.pop();  // Last burn.
    Append(std::move(manœuvre));
    return true;
  }
}

bool FlightPlan::set_final_time(Instant const& final_time) {
  if (!manœuvres_.empty() && manœuvres_.back().final_time() > final_time ||
      initial_time_ > final_time) {
    return false;
  } else {
    final_time_ = final_time;
    ResetLastSegment();
    CoastLastSegment(final_time_);
    return true;
  }
}

NavigationManœuvre FlightPlan::MakeManœuvre(Burn burn, Mass const & initial_mass) {
  NavigationManœuvre manœuvre(burn.thrust,
      initial_mass,
      burn.specific_impulse,
      Normalize(burn.Δv),
      std::move(burn.frame));
  manœuvre.set_initial_time(burn.initial_time);
  manœuvre.set_Δv(burn.Δv.Norm());
  return std::move(manœuvre);
}

void FlightPlan::Append(NavigationManœuvre manœuvre) {
  manœuvres_.emplace_back(std::move(manœuvre));
  ResetLastSegment();
  CoastLastSegment(manœuvre.initial_time());
  AddSegment();
  BurnLastSegment(manœuvre);
  AddSegment();
  CoastLastSegment(final_time_);
}

void FlightPlan::BurnLastSegment(NavigationManœuvre const& manœuvre) {
  ephemeris_->FlowWithAdaptiveStep(
      segments_.top().get(),
      manœuvre.acceleration(*segments_.top()),
      length_integration_tolerance_,
      speed_integration_tolerance_,
      integrator_,
      manœuvre.final_time());
}

void FlightPlan::CoastLastSegment(Instant const& final_time) {
  ephemeris_->FlowWithAdaptiveStep(
      segments_.top().get(),
      Ephemeris<Barycentric>::kNoIntrinsicAcceleration,
      length_integration_tolerance_,
      speed_integration_tolerance_,
      integrator_,
      final_time);
}

void FlightPlan::AddSegment() {
  segments_.emplace(segments_.top()->NewForkAtLast());
}

void FlightPlan::ResetLastSegment() {
  segments_.top()->ForgetAfter(segments_.top()->Fork().time());
}

}  // namespace ksp_plugin
}  // namespace principia
