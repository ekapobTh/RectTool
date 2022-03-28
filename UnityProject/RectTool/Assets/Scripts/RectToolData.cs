public class RectToolData
{
    public int current_screen;
    public string image_uri;
    public SubImageData[] sub_image;

    public RectToolData()
    {
        current_screen = 1;
        image_uri = string.Empty;
        sub_image = new SubImageData[1] { new SubImageData() };
    }

    public class SubImageData
    {
        public string image_uri;
        public string start_x;
        public string start_y;
        public string end_x;
        public string end_y;

        public SubImageData()
        {
            image_uri = string.Empty;
            start_x = string.Empty;
            start_y = string.Empty;
            end_x = string.Empty;
            end_y = string.Empty;
        }
    }
}