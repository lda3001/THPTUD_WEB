namespace TH_Harmic.Areas.Admin.Models
{
    public class SummerNote
    {
        public SummerNote(string idEditor, bool loadLibary = true)
        {
            IDEditor = idEditor;
            LoadLibary = loadLibary;
        }
        public string IDEditor { get; set; }
        public bool LoadLibary { get; set; }
        public int Height { get; set; } = 500;
        public string toolbar { get; set; } = @"
            [
                ['style', ['style']],
                ['font', ['bold', 'underline', 'clear']],
                ['color', ['color']],
                ['para', ['ol', 'ul', 'paragraph']],
                ['table',['table']],
                ['insert', ['link', 'elfinderFile', 'video', 'elfinder']],
                ['view', ['fullscreen', 'codeview', 'help']],
                
            ]
        ";
    }
}
