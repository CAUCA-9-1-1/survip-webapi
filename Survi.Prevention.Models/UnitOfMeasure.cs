using System;
using Survi.Prevention.Models.Base;

namespace Survi.Prevention.Models
{
  public class UnitOfMeasure : BaseModel
  {
    public string Abbreviation { get; set; }
    public string MeasureType { get; set; }

    public Guid IdLanguageContentName { get; set; }
  }
}
