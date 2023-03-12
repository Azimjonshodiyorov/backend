using System.Collections;

namespace NetCoreDemo.Models;

public class Image : BaseModel
{
    public string[] Url { get; set; } = null!;
}