using DataModels;

namespace ReportCard.DTOModels
{
    public class DayCodeDTO
    {
        public string CodeId { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"{CodeId} - {Description}";
        }
    }
}
