using PublishingHouse.DTOs;
using PublishingHouse.Models.PrintedEditionEntity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PublishingHouse.Interfaces
{
    public interface IPrintedEditionService
    {
        IEnumerable<PrintedEdition> LoadPrintedEditions();
        IEnumerable<PrintedEdition> LoadAvailablePrintedEditions();
        Task CreatePrintedEditionAsync(CreatePrintedEditionDTO createPrintedEditionDTO);
    }
}
