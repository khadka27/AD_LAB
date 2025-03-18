namespace WebApplication1.Models
{
    public class StudentModel
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }


 

    }

    public class StudentModelList
    {
        public List<StudentModel> StudentList { get; set; }
    }

    public class StudentModelResponse
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public StudentModel Student { get; set; }
    }

    public class StudentModelResponseList
    {
        public string Message { get; set; }
        public bool Status { get; set; }
        public List<StudentModel> StudentList { get; set; }
    }

    public class StudentModelRequest
    {
        public StudentModel Student { get; set; }
    }
}
