using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Base.AspCoreUtility.Infrastructure.Messages;

namespace Base.AspCoreUtility.Infrastructure.Messages;

/// <summary>
///     Version 3.0
/// </summary>
public static class Utility
{
    public static bool AddMessage
    (ITempDataDictionary tempData,
        MessageType type, string? message)
    {
        message =
            Framework.Utilities.Utility.FixText(text: message);

        if (message == null) return false;


        List<string>? list;

        var tempDataItems =
            tempData[type.ToString()] as
                IList<string>;

        if (tempDataItems == null)
        {
            list = new List<string>();
        }
        else
        {
            list =
                tempDataItems as
                    List<string>;

            if (list == null) list = tempDataItems.ToList();
        }

        tempData[type.ToString()] = list;
        // **************************************************

        if (list.Contains(message)) return false;

        list.Add(message);

        return true;
    }
}
