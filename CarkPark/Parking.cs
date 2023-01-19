
class Parking
{
    public static string  DoOperation(string op,Dictionary<string,string>carParkl)
    {
        string result=""; 
        switch (op)
        {
            case "List":
                result = "Lista";
                break;
            default:

                for (int i = 0; i < carParkl.Count() ; i++)
                {
                    if (carParkl.ElementAt(i).Key.Equals(op))
                    {
                        if (carParkl.ElementAt(i).Value.Equals("Empty"))
                        {
                            result = "Found";
                            break; 
                        }
                        else
                        {
                            result="Is occuped please enter the another parking number:";
                            break;
                        }
                    }
                    else {
                        result = "Error";
                    }
                }
                break;
        }
        return result;
    }


    public static string UpdateValue(string op, string value, Dictionary<string, string> carParkl)
    {
        string result = "error";
        // Use a switch

        for (int i = 0; i < carParkl.Count(); i++)
                {
                    if (carParkl.ElementAt(i).Key.Equals(op))
                    {
                        if (carParkl.ElementAt(i).Value.Equals("Empty"))
                        {
                            carParkl[carParkl.ElementAt(i).Key] = value;
                            result = "ok";
                        }
                    }
                }
        return result;
    }

}