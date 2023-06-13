using PublishingHouse.Models.PrintedEditionEntity;
using System.Collections.Generic;

namespace PublishingHouse.Interfaces
{
    public interface IPrintedEditionService
    {
        IEnumerable<PrintedEdition> LoadPrintedEditions();
    }
}
