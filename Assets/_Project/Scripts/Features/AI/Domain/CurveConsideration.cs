using UnityEngine;
using System;

namespace Project.Features.AI.Domain
{
    /// <summary>
    /// Represents the converter from world numbers to AI numbers (0-1).
    /// We can think of it as if we are converting a bunch of other currencies
    /// to one standard currency that the AI understand.
    /// </summary>
    public class CurveConsideration : IConsideration
    {
        private readonly string m_Name; // Debug.
        private readonly AnimationCurve m_Curve; // Math curve.
        private readonly Func<float> m_Source; // Input source.
        private readonly float m_Min, m_Max; // Ranges.

        public CurveConsideration(string name, AnimationCurve curve, Func<float> source, float min, float max)
        {
            m_Name = name;
            m_Curve = curve;
            m_Source = source;
            m_Min = min;
            m_Max = max;
        }

        public float Score => EvaluateCurve();

        private float EvaluateCurve()
        {
            float rawValue = m_Source.Invoke(); // Fetch the rawValue.
            float normalizedValue = (rawValue - m_Min) / (m_Max - m_Min); // Normalize the rawValue.
            normalizedValue = Mathf.Clamp01(normalizedValue); // Clamp it between 0 and 1.
            return m_Curve.Evaluate(normalizedValue);
        }
    }
}
