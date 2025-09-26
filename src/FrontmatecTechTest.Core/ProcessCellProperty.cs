using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrontmatecTechTest.Core;
public class ProcessCellProperty(string key, string value) : EntityBase
{
  public string Key { get; set; } = Guard.Against.NullOrEmpty(key, nameof(key));
  public string Value { get; set; } = Guard.Against.NullOrEmpty(value, nameof(value));
}
