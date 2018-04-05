using System;
using Survip.Models.Base;

namespace Survip.Models
{
  public class UnitOfMeasure : BaseModel
  {
    public string Abbreviation { get; set; }
    public string MeasureType { get; set; }

    public Guid IdLanguageContentName { get; set; }
  }
}
