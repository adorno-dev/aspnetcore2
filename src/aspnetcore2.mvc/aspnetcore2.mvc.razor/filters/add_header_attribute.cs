using Microsoft.AspNetCore.Mvc.Filters;

namespace AspnetCore2.Mvc.Filters
{
    public class AddHeaderAttribute : ResultFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;
        private readonly string[] _values;

        public AddHeaderAttribute(string name, string value)
            => (_name, _value) = (name, value);
        
        public AddHeaderAttribute(string name, string[] values)
            => (_name, _values) = (name, values);
        
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            if (!string.IsNullOrEmpty(_value))
                context.HttpContext.Response.Headers.Add(_name, new[] { _value });
            else if (_values.Length > 0)
                context.HttpContext.Response.Headers.Add(_name, _values);
                
            base.OnResultExecuting(context);
        }
    }
}