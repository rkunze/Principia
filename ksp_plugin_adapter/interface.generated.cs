// Warning!  This file was generated by running a program (see project |tools|).
// If you change it, the changes will be lost the next time the generator is
// run.  You should change the generator instead.

using System;
using System.Runtime.InteropServices;

namespace principia {
namespace ksp_plugin_adapter {

[StructLayout(LayoutKind.Sequential)]
internal partial struct NavigationFrameParameters {
  public int extension;
  public int centre_index;
  public int primary_index;
  public int secondary_index;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct XYZ {
  public double x;
  public double y;
  public double z;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct Burn {
  public double thrust_in_kilonewtons;
  public double specific_impulse_in_seconds_g0;
  public NavigationFrameParameters frame;
  public double initial_time;
  public XYZ delta_v;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct NavigationManoeuvre {
  public Burn burn;
  public double initial_mass_in_tonnes;
  public double final_mass_in_tonnes;
  public double mass_flow;
  public double duration;
  public double final_time;
  public double time_of_half_delta_v;
  public double time_to_half_delta_v;
  public XYZ direction;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct KSPPart {
  public XYZ world_position;
  public XYZ world_velocity;
  public double mass_in_tonnes;
  public XYZ gravitational_acceleration_to_be_applied_by_ksp;
  public uint id;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct QP {
  public XYZ q;
  public XYZ p;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct WXYZ {
  public double w;
  public double x;
  public double y;
  public double z;
}

[StructLayout(LayoutKind.Sequential)]
internal partial struct XYZSegment {
  public XYZ begin;
  public XYZ end;
}

internal static partial class Interface {

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__AddVesselToNextPhysicsBubble",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void AddVesselToNextPhysicsBubble(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid,
      KSPPart[] parts,
      int count);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__AdvanceTime",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void AdvanceTime(
      this IntPtr plugin,
      double t,
      double planetarium_rotation);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__AtEnd",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern bool AtEnd(
      this IntPtr line_and_iterator);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__BubbleDisplacementCorrection",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern XYZ BubbleDisplacementCorrection(
      this IntPtr plugin,
      XYZ sun_position);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__BubbleVelocityCorrection",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern XYZ BubbleVelocityCorrection(
      this IntPtr plugin,
      int reference_body_index);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__CelestialFromParent",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern QP CelestialFromParent(
      this IntPtr plugin,
      int celestial_index);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__CurrentTime",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern double CurrentTime(
      this IntPtr plugin);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__DeleteLineAndIterator",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void DeleteLineAndIterator(
      ref IntPtr line_and_iterator);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__DeletePlugin",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void DeletePlugin(
      ref IntPtr plugin);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__DeletePluginSerialization",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void DeletePluginSerialization(
      ref IntPtr serialization);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__DeserializePlugin",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void DeserializePlugin(
      [MarshalAs(UnmanagedType.LPStr)] String serialization,
      int serialization_size,
      ref IntPtr deserializer,
      ref IntPtr plugin);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__DirectlyInsertCelestial",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void DirectlyInsertCelestial(
      this IntPtr plugin,
      int celestial_index,
      ref int parent_index,
      [MarshalAs(UnmanagedType.LPStr)] String gravitational_parameter,
      [MarshalAs(UnmanagedType.LPStr)] String axis_right_ascension,
      [MarshalAs(UnmanagedType.LPStr)] String axis_declination,
      [MarshalAs(UnmanagedType.LPStr)] String j2,
      [MarshalAs(UnmanagedType.LPStr)] String reference_radius,
      [MarshalAs(UnmanagedType.LPStr)] String x,
      [MarshalAs(UnmanagedType.LPStr)] String y,
      [MarshalAs(UnmanagedType.LPStr)] String z,
      [MarshalAs(UnmanagedType.LPStr)] String vx,
      [MarshalAs(UnmanagedType.LPStr)] String vy,
      [MarshalAs(UnmanagedType.LPStr)] String vz);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__EndInitialization",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void EndInitialization(
      this IntPtr plugin);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__FetchAndIncrement",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern XYZSegment FetchAndIncrement(
      this IntPtr line_and_iterator);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__FlightPlanAppend",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern bool FlightPlanAppend(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid,
      Burn burn);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__FlightPlanCreate",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void FlightPlanCreate(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid,
      double final_time,
      double mass_in_tonnes);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__FlightPlanDelete",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void FlightPlanDelete(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__FlightPlanGetManoeuvre",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern NavigationManoeuvre FlightPlanGetManoeuvre(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid,
      int index);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__FlightPlanNumberOfManoeuvres",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int FlightPlanNumberOfManoeuvres(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__FlightPlanNumberOfSegments",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int FlightPlanNumberOfSegments(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__FlightPlanRemoveLast",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void FlightPlanRemoveLast(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__FlightPlanRenderedSegment",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr FlightPlanRenderedSegment(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid,
      XYZ sun_world_position,
      int index);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__FlightPlanReplaceLast",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern bool FlightPlanReplaceLast(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid,
      Burn burn);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__FlightPlanSetFinalTime",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern bool FlightPlanSetFinalTime(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid,
      double final_time);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__FlightPlanSetTolerances",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void FlightPlanSetTolerances(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid,
      double length_integration_tolerance,
      double speed_integration_tolerance);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__ForgetAllHistoriesBefore",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void ForgetAllHistoriesBefore(
      this IntPtr plugin,
      double t);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__GetBufferDuration",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int GetBufferDuration();

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__GetBufferedLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int GetBufferedLogging();

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__GetNavigationFrameParameters",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern NavigationFrameParameters GetNavigationFrameParameters(
      IntPtr navigation_frame);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__GetPlottingFrame",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr GetPlottingFrame(
      IntPtr plugin);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__GetStderrLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int GetStderrLogging();

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__GetSuppressedLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int GetSuppressedLogging();

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__GetVerboseLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int GetVerboseLogging();

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__HasPrediction",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern bool HasPrediction(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__HasVessel",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern bool HasVessel(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__InitGoogleLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void InitGoogleLogging();

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__InsertCelestial",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void InsertCelestial(
      this IntPtr plugin,
      int celestial_index,
      double gravitational_parameter,
      int parent_index,
      QP from_parent);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__InsertOrKeepVessel",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern bool InsertOrKeepVessel(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid,
      int parent_index);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__InsertSun",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void InsertSun(
      this IntPtr plugin,
      int celestial_index,
      double gravitational_parameter);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__LogError",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void LogError(
      [MarshalAs(UnmanagedType.LPStr)] String text);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__LogFatal",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void LogFatal(
      [MarshalAs(UnmanagedType.LPStr)] String text);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__LogInfo",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void LogInfo(
      [MarshalAs(UnmanagedType.LPStr)] String text);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__LogWarning",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void LogWarning(
      [MarshalAs(UnmanagedType.LPStr)] String text);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__NavballOrientation",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern WXYZ NavballOrientation(
      this IntPtr plugin,
      XYZ sun_world_position,
      XYZ ship_world_position);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__NewBarycentricRotatingNavigationFrame",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr NewBarycentricRotatingNavigationFrame(
      this IntPtr plugin,
      int primary_index,
      int secondary_index);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__NewBodyCentredNonRotatingNavigationFrame",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr NewBodyCentredNonRotatingNavigationFrame(
      this IntPtr plugin,
      int reference_body_index);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__NewNavigationFrame",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr NewNavigationFrame(
      this IntPtr plugin,
      NavigationFrameParameters parameters);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__NewPlugin",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr NewPlugin(
      double initial_time,
      double planetarium_rotation_in_degrees);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__NumberOfSegments",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern int NumberOfSegments(
      this IntPtr line_and_iterator);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__PhysicsBubbleIsEmpty",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern bool PhysicsBubbleIsEmpty(
      this IntPtr plugin);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__RenderedPrediction",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr RenderedPrediction(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid,
      XYZ sun_world_position);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__RenderedVesselTrajectory",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr RenderedVesselTrajectory(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid,
      XYZ sun_world_position);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__SayHello",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr SayHello();

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__SerializePlugin",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern IntPtr SerializePlugin(
      this IntPtr plugin,
      ref IntPtr serializer);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__SetBufferDuration",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetBufferDuration(
      int seconds);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__SetBufferedLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetBufferedLogging(
      int max_severity);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__SetPlottingFrame",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetPlottingFrame(
      this IntPtr plugin,
      ref IntPtr navigation_frame);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__SetPredictionLength",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetPredictionLength(
      this IntPtr plugin,
      double t);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__SetPredictionLengthTolerance",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetPredictionLengthTolerance(
      this IntPtr plugin,
      double l);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__SetPredictionSpeedTolerance",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetPredictionSpeedTolerance(
      this IntPtr plugin,
      double v);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__SetStderrLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetStderrLogging(
      int min_severity);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__SetSuppressedLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetSuppressedLogging(
      int min_severity);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__SetVerboseLogging",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetVerboseLogging(
      int level);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__SetVesselStateOffset",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void SetVesselStateOffset(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid,
      QP from_parent);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__UpdateCelestialHierarchy",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void UpdateCelestialHierarchy(
      this IntPtr plugin,
      int celestial_index,
      int parent_index);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__UpdatePrediction",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern void UpdatePrediction(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__VesselBinormal",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern XYZ VesselBinormal(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__VesselFromParent",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern QP VesselFromParent(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__VesselNormal",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern XYZ VesselNormal(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid);

  [DllImport(dllName           : kDllPath,
             EntryPoint        = "principia__VesselTangent",
             CallingConvention = CallingConvention.Cdecl)]
  internal static extern XYZ VesselTangent(
      this IntPtr plugin,
      [MarshalAs(UnmanagedType.LPStr)] String vessel_guid);

}

}  // namespace ksp_plugin_adapter
}  // namespace principia
