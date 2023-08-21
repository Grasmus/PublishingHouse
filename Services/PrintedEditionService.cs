using PublishingHouse.DTOs;
using PublishingHouse.Interfaces;
using PublishingHouse.Models.PrintedEditionEntity;
using PublishingHouse.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

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

        public async Task CreatePrintedEditionAsync(CreatePrintedEditionDTO createPrintedEditionDTO)
        {
            PrintedEditionRepository printedEditionRepository = _unitOfWork.PrintedEditionRepository;

            PrintedEdition printedEdition = new PrintedEdition()
            {
                Author = createPrintedEditionDTO.Author,
                Title = createPrintedEditionDTO.Title,
                Genre = createPrintedEditionDTO.Genre,
                Language = createPrintedEditionDTO.Language,
                Description = createPrintedEditionDTO.Description,
                Cover = createPrintedEditionDTO.Cover,
                Category = createPrintedEditionDTO.Category,
                IsAvailable = createPrintedEditionDTO.IsAvailable,
                Price = createPrintedEditionDTO.Price,
                ReleaseDate = createPrintedEditionDTO.ReleaseDate,
                Updated = DateTime.Now
            };

            await printedEditionRepository.AddAsync(printedEdition);
            await _unitOfWork.SaveChangesAsync();
        }

        public IEnumerable<PrintedEdition> LoadAvailablePrintedEditions()
        {
            PrintedEditionRepository printedEditionRepository = _unitOfWork.PrintedEditionRepository;

            IEnumerable<PrintedEdition> printedEditions = printedEditionRepository.GetAvailable();

            return printedEditions;
        }

        public async Task UpdatePrintedEditionAsync(PrintedEdition printedEdition)
        {
            PrintedEditionRepository printedEditionRepository = _unitOfWork.PrintedEditionRepository;

            printedEditionRepository.Update(printedEdition);

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
