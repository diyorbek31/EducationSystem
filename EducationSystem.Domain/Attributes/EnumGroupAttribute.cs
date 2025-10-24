using EducationSystem.Domain.Commons;

namespace EducationSystem.Domain.Attributes;

public class EnumGroupAttribute
{
    public MultiLanguageField GroupName { get; set; }

    public EnumGroupAttribute(object name)
    {
        this.GroupName = name.ToString() ?? "Default";
    }

    public EnumGroupAttribute(MultiLanguageField name)
    {
        this.GroupName = name;
    }

    public EnumGroupAttribute(string? nameUz, string? nameEng, string? nameRu, string? nameCyrl)
    {
        this.GroupName = new MultiLanguageField()
        {
            En = nameEng ?? string.Empty,
            Ru = nameRu ?? string.Empty,
            Uz = nameUz ?? string.Empty,
            Cyrl = nameCyrl ?? string.Empty,
        };
    }

    public EnumGroupAttribute(string name)
    {
        this.GroupName = name;
    }

    public EnumGroupAttribute()
    {
        this.GroupName = "Default";
    }
}
