using System.ComponentModel.DataAnnotations;

namespace api.ModelDefinitions;

[Serializable]
public record class SomeModelDefinition : IModelDefinition
{
    [Required]
    [StringLength(100)]
    public String SomeProperty { get; set; }

    [Required]
    [StringLength(100)]
    public String SomeOtherProperty { get; set; }

}