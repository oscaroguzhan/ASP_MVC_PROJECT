
using System.Reflection;

namespace Domain.Extensions;

public static class MappingExtensions
{
    public static TDestination MapTo<TDestination>(this object source)
    {
        ArgumentNullException.ThrowIfNull(source, nameof(source));
        TDestination destination = Activator.CreateInstance<TDestination>();

        var sourceProperties = source.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
        var destinationProperties = typeof(TDestination).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var sourceProperty in sourceProperties)
        {
            var destinationProperty = Array.Find(destinationProperties, p => p.Name == sourceProperty.Name);
            if (destinationProperty != null && destinationProperty.CanWrite)
            {
                var value = sourceProperty.GetValue(source);
                destinationProperty.SetValue(destination, value);
            }
        }
        return destination;
    }
}
