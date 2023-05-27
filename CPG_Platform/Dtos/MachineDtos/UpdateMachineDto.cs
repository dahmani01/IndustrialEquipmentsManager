namespace CPG_Platform.Dtos.MachineDtos
{
    public class UpdateMachineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool enService { get; set; }
        public int ServiceId { get; set; }
    }
}
