namespace CSCG.Abstract.Entities.Methods
{
    public class ParameterEntityBase
    {
        public string ParameterTypeName { get; }

        public string ParameterName { get; }

        public ParameterEntityBase(string parameterTypeName, string parameterName)
        {
            ParameterTypeName = parameterTypeName;
            ParameterName = parameterName;
        }
    }
}