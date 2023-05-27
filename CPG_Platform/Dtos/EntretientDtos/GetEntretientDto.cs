namespace CPG_Platform.Dtos.EntretientDtos
{
    public class GetEntretientDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string UserFirstName { get; set; }
        public string UserLastName { get; set; }
        public string UserMatricule { get; set; }
        public string MachineName { get; set; }
        public int MachineId { get; set; }  

    }
}
