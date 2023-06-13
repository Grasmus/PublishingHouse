using PublishingHouse.Interfaces;
using PublishingHouse.Models.PrintedEditionEntity;
using PublishingHouse.Repositories;
using System.Collections.Generic;

namespace PublishingHouse.Services
{
    public class PrintedEditionService : IPrintedEditionService
    {
        private readonly UnitOfWork _unitOfWork;

        public PrintedEditionService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<PrintedEdition> LoadPrintedEditions()
        {
            PrintedEditionRepository printedEditionRepository = _unitOfWork.PrintedEditionRepository;

            return printedEditionRepository.GetAll();
        }

        public IEnumerable<PrintedEdition> GetPrintedEditions(IEnumerable<int> printedEditionIds)
        {
            PrintedEditionRepository printedEditionRepository = _unitOfWork.PrintedEditionRepository;

            List<PrintedEdition> printedEditions = new List<PrintedEdition>();

            foreach(int id in printedEditionIds) 
            {
                printedEditions.Add(printedEditionRepository.GetById(id));
            }

            return printedEditions;
        }
    }
}
