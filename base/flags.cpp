#include "base/flags.hpp"

namespace principia {
namespace base {

void Flags::Clear() {
  flags_.clear();
}

void Flags::Set(std::string_view const name, std::string_view const value) {
  flags_.emplace(std::string(name), std::string(value));
}

bool Flags::IsPresent(std::string_view const name) {
  return flags_.find(std::string(name)) != flags_.end();
}

bool Flags::IsPresent(std::string_view const name,
                      std::string_view const value) {
  auto const pair = flags_.equal_range(std::string(name));
  std::set<std::string> values;
  for (auto it = pair.first; it != pair.second; ++it) {
    if (it->second == value) {
      return true;
    }
  }
  return false;
}

std::set<std::string> Flags::Values(std::string_view const name) {
  auto const pair = flags_.equal_range(std::string(name));
  std::set<std::string> values;
  for (auto it = pair.first; it != pair.second; ++it) {
    values.insert(it->second);
  }
  return values;
}

std::multimap<std::string, std::string> Flags::flags_;

}  // namespace base
}  // namespace principia
