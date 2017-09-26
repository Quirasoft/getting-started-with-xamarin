namespace BMIApp
{
    public class Calculator
    {
        /// <summary>
        /// Calculate the body mass index (BMI) to evalute the body mass of a person.
        /// </summary>
        /// <param name="weight">The weight in kilograms</param>
        /// <param name="height">The height in meters</param>
        /// <returns>The BMI of the person</returns>
        public static float CalculateBodyMassIndex(float weight,float height)
        {
            return weight / (height * height);
        }
    }
}
