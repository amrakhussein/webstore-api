namespace SimpleWebStore.Data;

public class ProductsDummyData
{


    public static string[] ImageSrcs
    {
        get
        {
            string[] srcs = new string[] {
            "https://images.unsplash.com/photo-1523275335684-37898b6baf30?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=1099&q=80",
            "https://images.unsplash.com/photo-1546868871-7041f2a55e12?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=764&q=80",
            "https://plus.unsplash.com/premium_photo-1675431443185-9d40521c8d5c?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8&auto=format&fit=crop&w=751&q=80"
            };
            return srcs;

        }
    }

    public static string[] Names
    {
        get
        {
            string[] titles = { "Labtop", "Some Product", "Bottle", "Super Product", "Premium Product" };

            return titles;
        }
    }

    public static int[] Prices
    {
        get
        {
            int[] prices = { 20, 40, 11, 4, 23, 30 };
            return prices;
        }
    }
    public static double[] AverageRatings
    {
        get
        {
            double[] averageRatings = { 2.2, 3.5, 4.1, 4.9, 3.2 };
            return averageRatings;
        }
    }

    public static string[] Descriptions
    {
        get
        {
            string[] descriptions = new string[] { "simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.", "standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged.", "simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries" };
            return descriptions;
        }
    }

}

