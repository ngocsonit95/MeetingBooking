using Model.EF;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Windows.Forms;
using static MeetingBooking.Helper.Enums;
using static MeetingBooking.Helper.CodeUtility;

namespace MeetingBooking.Helper
{
  public static class CodeUtility
  {
    /// <summary>
    /// Chuyển value về dạng chuỗi.
    /// Trả về dạng chuỗi của value
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi. </param>
    /// <returns>Trả về dạng chuỗi của value.</returns>
    public static string ToSafetyString(this object value)
    {
      if (value == null)
      {
        return string.Empty;
      }

      return value.ToString();

    }

    /// <summary>
    /// Chuyển value về dạng số nguyên(byte).
    /// Trả về dạng số nguyên(byte) của value
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi. </param>
    /// <returns>Trả về dạng số nguyên (byte) của value.</returns>
    public static byte ToByte(this object value)
    {
      if (value == null)
        return 0;
      //Khai báo giá trị chứa kết quả mặ định, mặc định là 0
      byte result = 0;

      //Thử ép value thành kiểu byte
      byte.TryParse(value.ToString(), out result);

      //Trả về kết quả đã ép kiểu
      return result;
    }

    /// <summary>
    /// Chuyển value về dạng số nguyên(SByte).
    /// Trả về dạng số nguyên(SByte) của value
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi. </param>
    /// <returns>Trả về dạng số nguyên (SByte) của value.</returns>
    public static SByte ToSByte(this object value)
    {
      if (value == null || value.ToString() == string.Empty)
        return 0;
      sbyte result = 0;
      sbyte.TryParse(value.ToString(), out result);
      return result;
    }

    /// <summary>
    /// Chuyển value về dạng số nguyên(Short).
    /// Trả về dạng số nguyên(Short) của value
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi. </param>
    /// <returns>Trả về dạng số nguyên (Short) của value.</returns>
    public static short ToShort(this object value)
    {
      if (value == null || value.ToString() == string.Empty)
        return 0;
      short result = 0;
      short.TryParse(value.ToString(), out result);
      return result;
    }

    /// <summary>
    /// Chuyển value về dạng số nguyên(ToUInt).
    /// Trả về dạng số nguyên(ToUInt) của value
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi. </param>
    /// <returns>Trả về dạng số nguyên (ToUInt) của value.</returns>
    public static uint ToUInt(this object value)
    {
      if (value == null || value.ToString() == string.Empty)
        return 0;

      ushort result = 0;

      ushort.TryParse(value.ToString(), out result);

      return result;
    }

    /// <summary>
    /// Chuyển value về dạng số nguyên(Ushort).
    /// Trả về dạng số nguyên(Ushort) của value
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi. </param>
    /// <returns>Trả về dạng số nguyên (Ushort) của value.</returns>
    public static ushort ToUShort(this object value)
    {
      if (value == null || value.ToString() == string.Empty)
        return 0;

      ushort result = 0;

      ushort.TryParse(value.ToString(), out result);

      return result;
    }

    /// <summary>
    /// Chuyển value về dạng số nguyên(int).
    /// Trả về dạng số nguyên(int) của value
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi. </param>
    /// <returns>Trả về dạng số nguyên (int) của value.</returns>
    public static int ToInt(this object value)
    {
      if (value == null || value.ToString() == string.Empty)
        return 0;
      int result = 0;
      int.TryParse(value.ToString(), out result);
      return result;
    }

    /// <summary>
    /// Chuyển value về dạng số thực(Float).
    /// Trả về dạng số thực(Float) của value
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi. </param>
    /// <returns>Trả về dạng số thực (Float) của value.</returns>
    public static float ToFloat(this object value)
    {
      if (value == null || value.ToString() == string.Empty)
        return 0;
      float result = 0;
      float.TryParse(value.ToString(), out result);
      return result;
    }

    /// <summary>
    /// Chuyển value về dạng số thực(Double).
    /// Trả về dạng số thực (Double) của value
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi. </param>
    /// <returns>Trả về dạng số thực (double) của value.</returns>
    public static double ToDouble(this object value)
    {
      if (value == null || value.ToString() == string.Empty)

        return 0;

      double result = 0;

      double.TryParse(value.ToString(), out result);

      return result;
    }

    /// <summary>
    /// Chuyển value về dạng số thực(Long).
    /// Trả về dạng số thực (Long) của value
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi. </param>
    /// <returns>Trả về dạng số thực (Long) của value.</returns>
    public static long ToLong(this object value)
    {
      if (value == null || value.ToString() == string.Empty)

        return 0;

      long result = 0;

      long.TryParse(value.ToString(), out result);

      return result;
    }

    /// <summary>
    /// Chuyển value về dạng số thực(Long).
    /// Trả về dạng số thực (Long) của value
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi. </param>
    /// <returns>Trả về dạng số thực (Long) của value.</returns>
    public static ulong ToULong(this object value)
    {
      if (value == null || value.ToString() == string.Empty)

        return 0;

      ulong result = 0;

      ulong.TryParse(value.ToString(), out result);

      return result;
    }

    /// <summary>
    /// Chuyển value về dạng số thực(decimal).
    /// Trả về dạng số thực (decimal) của value
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi. </param>
    /// <returns>Trả về dạng số thực (decimal) của value.</returns>
    public static decimal ToDecimal(this object value)
    {
      if (value == null || value.ToString() == string.Empty)
        return 0;

      decimal result = 0;

      decimal.TryParse(value.ToString(), out result);

      return result;
    }

    /// <summary>
    /// Chuyển value về dạng kí tự (char).
    /// Trả về dạng kí tự (char) của value
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi. </param>
    /// <returns>Trả về dạng kí tự (char) của value.</returns>
    public static char ToChar(this object value)
    {
      //Tối ưu hơn phân cách khi dùng hàm ||
      if (value == null || value.ToString() == string.Empty || (value.ToString().Length > 1))
      {
        return ' ';
      }
      char result = ' ';
      char.TryParse(value.ToString(), out result);
      return result;
    }

    /// <summary>
    /// Chuyển value về dạng luận lý (bool).
    /// Trả về dạng luận lý (bool) của value
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi. </param>
    /// <returns>Trả về dạng luận lý (bool) của value.</returns>
    public static bool ToBool(this object value)
    {
      if (value == null)
      {
        return false;
      }

      if (value.ToInt() == 1)
      {
        return true;
      }

      bool result = false;
      bool.TryParse(value.ToString(), out result);
      return result;
    }

    /// <summary>
    /// Chuyển value về dạng ngày giờ (DateTime).
    /// Trả về dạng ngày giờ (DateTime) của value
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi. </param>
    /// <returns>Trả về dạng ngày giờ (DateTime) của value.</returns>
    public static DateTime ToDateTime(this object value)
    {
      if (value == null || value.ToString() == string.Empty || value.ToString() == " ")
        return DateTime.MinValue;

      DateTime result = DateTime.MinValue;

      string[] formats = {"d/M/yyyy", "dd/MM/yyyy", "d/M/yyyy HH:mm:ss", "d/M/yyyy HH:mm", "dd/MM/yyyy HH:mm", "HH:mm:ss", "HH:mm",
"d-M-yyyy", "dd-MM-yyyy", "d-M-yyyy HH:mm:ss", "d-M-yyyy HH:mm", "dd-MM-yyyy HH:mm", "HH:mm:ss", "HH:mm"};//HH phủ cả từ 1-24h còn hh chỉ phủ từ 1-12h

      string[] dateStrings = {"5/1/2009 6:32 PM", "05/01/2009 6:32:05 PM",
                              "5/1/2009 6:32:00", "05/01/2009 06:32",
                              "05/01/2009 06:32:00 PM", "05/01/2009 06:32:00"};
      DateTime.TryParseExact(value.ToString(), formats,
                              //new CultureInfo("en-US"),//Lấy văn hóa của Mỹ
                              CultureInfo.CurrentCulture,//Lấy văn hóa của máy tính đang dùng
                              DateTimeStyles.None,
                              out result);
      return result;

    }

    /// <summary>
    /// Kiểm tra value có Null hoặc Empty hay không?
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static bool IsNullOrEmpty(this object value)
    {
      if (value == null)
      {
        return true;
      }
      return string.IsNullOrEmpty(value.ToString());
    }

    /// <summary>
    /// Mã hóa SHA256Hash
    /// </summary>
    /// <param name="rawData"></param>
    /// <returns></returns>
    public static string SHA256Hash(this string rawData)
    {
      // Create a SHA256
      using (SHA256 sha256Hash = SHA256.Create())
      {
        // ComputeHash - returns byte array
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

        // Convert byte array to a string
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
          builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
      }
    }

    /// <summary>
    ///Thay thế các kí tự đặc biệt
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public static string ReplaceSpecial(this string value)
    {
      if (value != string.Empty)
      {
        value = Regex.Replace(value, @"(\s+|@|&|'|\(|\)|<|>|#|+|-)", "");
      }
      return value;
    }

    /// <summary>
    /// Random 2 số cho trước
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static int RandomNumber(int min, int max)
    {
      int seed = Guid.NewGuid().GetHashCode();
      Random item = new Random(seed);
      int result = item.Next(min, max);
      return result;
    }

    /// <summary>
    /// Tạo ra một chuỗi ngẫu nhiên với độ dài cho trước
    /// </summary>
    /// <param name="size">Kích thước của chuỗi </param>
    /// <param name="lowerCase">Nếu đúng, tạo ra chuỗi chữ thường</param>
    /// <returns>Random string</returns>
    public static string RandomString(int minLength, int maxLenngth, bool hasNumber = false, bool hasSymbol = false, bool hasUppercase = false)
    {
      //Nếu minLength,maxLength <0 và minLength > maxLength, thì trả về empty;
      if ((minLength <= 0 || maxLenngth <= 0) || minLength > maxLenngth)
      {
        return "Sai điều kiện";
      }

      //Tính chiều dài (Ngẫu nhiên, trong khoản min-max) của chuổi kết quả
      int length = RandomNumber(minLength, maxLenngth);

      //Khai báo chuổi chứa các kí tự có thể có
      string letters = "abcdefghijklmnopqrstuvwxyz";

      //Khai báo chuỗi chứa các kí tự số có thể có
      string numbers = "0123456789";

      //Khai báo chuỗi chứa các kí tự Ký hiệu có thể có
      string symbols = "!@#$%^&*()";

      //Khai báo chuỗi chứa các kí tự Chữ hoa có thể có
      string lettersUpers = letters.ToUpper();


      //Khai báo biến chứa kết quả là các ký tự ngẫu nhiên chọn được ,
      string result = string.Empty;

      //Khai báo chuỗi chứa các kí tự tổng hợp có thể có;
      string allChars = letters;
      if (hasNumber)
      {
        allChars += numbers;
      }
      if (hasSymbol)
      {
        allChars += symbols;
      }
      if (hasUppercase)
      {
        allChars += lettersUpers;
      }

      //Tiến hành chạy vòng lặp

      //để chọn lần lượt  các ký tự , mỗi lần bốc 1 kí tự ngẫu nhiên trong chuỗi quy định
      for (int i = 0; i < length; i++)
      {
        //Chỉ định một vị trí ngẫu nhiên , nằm trong khoảng chiều dài của chuổi quy định
        int index = RandomNumber(0, allChars.Length - 1);

        //Lấy kí tự tại vị trí đã chỉ định
        char item = allChars[index];

        //Cộng dồn kí tự đã lấy vào kết quả
        result += item;
      }
      //Trả về kết quả
      return result;


    }

    /// <summary>
    /// Random số bất kì
    /// </summary>
    /// <returns></returns>
    public static string RandomID()
    {
      return Guid.NewGuid().ToString();
    }

    #region RoundToInt
    /// <summary>
    /// Làm tròn một số có kiểu float, lấy 0 số thập phân, sau đó chuyển đổi sang kiểu int.
    /// Trả về số sau khi đã làm tròn và chuyển sang kiểu int.
    /// </summary>
    /// <param name="value">Số cần làm tròn và chuyển đổi kiểu.</param>
    /// <returns>Trả về số sau khi đã làm tròn và chuyển sang kiểu int.</returns>
    public static int RoundToInt(this float value)
    {
      return Math.Round(value).ToInt();
    }

    /// <summary>
    /// Làm tròn một số có kiểu double, lấy 0 số thập phân, sau đó chuyển đổi sang kiểu int.
    /// Trả về số sau khi đã làm tròn và chuyển sang kiểu int.
    /// </summary>
    /// <param name="value">Số cần làm tròn và chuyển đổi kiểu.</param>
    /// <returns>Trả về số sau khi đã làm tròn và chuyển sang kiểu int.</returns>
    public static int RoundToInt(this double value)
    {
      return Math.Round(value).ToInt();
    }
    #endregion

    #region ToStringSafe
    /// <summary>
    /// Chuyển đổi sang kiểu chuỗi, có tùy chọn cắt khoảng trắng ở 2 đầu
    /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
    /// </summary>
    /// <param name="value">Dữ liệu cần chuyển đổi</param>
    /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
    /// <param name="isTrim">
    /// Cho phép cắt khoảng trắng ở 2 đầu (nếu có).
    /// True: có cắt khoảng trắng ở 2 đầu;
    /// False: không cắt khoảng trắng ở 2 đầu
    /// </param>
    /// <returns>
    /// Trả về dạng chuỗi của giá trị cần chuyển đổi.
    /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
    /// </returns>
    public static string ToStringSafe(this object value, string defaultValue, bool isTrim)
    {
      //Nếu dữ liệu cần chuyển đổi là null, thì trả về giá trị mặc định
      if (value == null)
        return defaultValue;

      //Chuyển sang kiểu chuổi
      string convertedValue = value.ToString();

      //Cắt khoảng trắng nếu có thiết lập isTrim
      if (isTrim)
        convertedValue = convertedValue.Trim();

      //Trả về giá trị đã được chuyển đổi kiểu
      return convertedValue;
    }

    /// <summary>
    /// Chuyển đổi sang kiểu chuỗi.
    /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
    /// </summary>
    /// <param name="value">Dữ liệu cần chuyển đổi</param>
    /// <param name="defaultValue">Giá trị mặc định sẽ trả về nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ</param>
    /// <returns>
    /// Trả về dạng chuỗi của giá trị cần chuyển đổi.
    /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là defaultValue
    /// </returns>
    public static string ToStringSafe(this object value, string defaultValue)
    {
      return ToStringSafe(value, defaultValue, false);
    }

    /// <summary>
    /// Chuyển đổi sang kiểu chuỗi, có tùy chọn cắt khoảng trắng ở 2 đầu
    /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là Empty
    /// </summary>
    /// <param name="value">Dữ liệu cần chuyển đổi</param>
    /// <param name="isTrim">
    /// Cho phép cắt khoảng trắng ở 2 đầu (nếu có).
    /// True: có cắt khoảng trắng ở 2 đầu;
    /// False: không cắt khoảng trắng ở 2 đầu
    /// </param>
    /// <returns>
    /// Trả về dạng chuỗi của giá trị cần chuyển đổi, có tùy chọn cắt khoảng trắng ở 2 đầu
    /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là Empty
    /// </returns>
    public static string ToStringSafe(this object value, bool isTrim)
    {
      return ToStringSafe(value, string.Empty, isTrim);
    }

    /// <summary>
    /// Chuyển đổi sang kiểu chuỗi.
    /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là Empty
    /// </summary>
    /// <param name="value">Dữ liệu cần chuyển đổi</param>
    /// <returns>
    /// Trả về dạng chuỗi của giá trị cần chuyển đổi.
    /// Nếu giá trị cần chuyển đổi chứa dữ liệu không hợp lệ, trả về giá trị mặc định là Empty
    /// </returns>
    public static string ToStringSafe(this object value)
    {
      return ToStringSafe(value, string.Empty, false);
    }
    #endregion

  }

  public static class StringUtility
  {
    /// <summary>
    /// Nén khoảng trắng trong value.Thay hay hai hoặc nhiều khoảng trắng gần nhau thành 1 khoảng trắng trong value
    /// Trả về giá trị đã nén khoảng trắng
    /// </summary>
    /// <param name="value">Giá trị cần nén khoảng trắng</param>
    /// <param name="isTrim">Có tự động cắt khoảng trắng thừa 2 đầu không?
    /// true có false không
    /// </param>
    /// <returns>Trả về giá trị đã nén khoảng trắng</returns>
    public static string CompactSpaces(this object value, bool isTrim = false)
    {
      if (value == null)
      {
        return string.Empty;
      }

      string result = value.ToString();

      if (isTrim)
      {
        result = result.Trim();
      }
      // Cách 1:
      // do
      // {
      //     result = value.ToString().Replace("  ", " ");
      // } while (result.Contains("  "));

      // //Cach 2
      // while (result.Contains("  "))
      // {
      //     result = value.ToString().Replace("  ", " ");
      // }

      result = Regex.Replace(result, @"\s+", " ");

      return result;
    }

    /// <summary>
    /// Chuyển đổi value sang kiểu chữ thường.Trả về giá trị  kiểu chữ thường
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi</param>
    /// <param name="isTrim">Có tự động cắt khoảng trắng 2 đầu không? True: có; false: không
    /// </param><returns>Trả về giá trị  kiểu chữ thường</returns>
    public static string ToLowerCase(this object value, bool isTrim = false)
    {
      if (value == null)
      {
        return string.Empty;
      }

      string result = value.ToString();
      if (isTrim)
        result = result.Trim();

      return result.ToLower();
    }

    /// <summary>
    /// Chuyển đổi value sang kiểu chữ hoa.Trả về giá trị  kiểu chữ hoa
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi</param>
    /// <param name="isTrim">Có tự động cắt khoảng trắng 2 đầu không? True: có; false: không
    /// </param><returns>Trả về giá trị  kiểu chữ hoa</returns>
    public static string ToUpperCase(this object value, bool isTrim = false)
    {
      if (value == null)
      {
        return string.Empty;
      }

      string result = value.ToString();
      if (isTrim)
        result = result.Trim();

      return result.ToUpper();
    }

    /// <summary>
    /// Chuyển đổi value sang kiểu chữ tiêu đề(in hoa mỗi kí tự đầu tiên).
    /// Trả về giá trị  kiểu chữ tiêu đề(in hoa mỗi kí tự đầu tiên)
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi</param>
    /// <param name="isTrim">Có tự động cắt khoảng trắng 2 đầu không? True: có; false: không
    /// </param><returns>Trả về giá trị  kiểu chữ tiêu đề(in hoa mỗi kí tự đầu tiên)</returns>
    public static string ToTitleCase(this object value, bool isTrim = false)
    {
      if (value == null)
      {
        return string.Empty;
      }
      string result = StringUtility.ToLowerCase(value);

      if (isTrim)
        result = result.Trim();

      TextInfo textInfo = CultureInfo.InvariantCulture.TextInfo;
      //string result = value.ToLowerCase(); ĐƯỢC NHƯNG KHÔNG AN TOÀN

      return textInfo.ToTitleCase(result);

    }

    /// <summary>
    /// Chuyển đổi value thành không dấu
    /// trả về giá trị value không dấu
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi</param>
    /// <param name="isTrim">Có tự động cắt khoảng trắng 2 đầu không? True: có; false: không
    /// </param>
    /// <returns>trả về giá trị value không dấu</returns>
    public static string ToNoSignFormat(this object value, bool isTrim = false)
    {
      if (value == null)
      {
        return string.Empty;
      }
      string result = value.ToString();
      if (isTrim)
        result = result.Trim();
      //result = Regex.Replace(result, "[óòỏõọôốồổỗộơớờởỡợ]", "o");
      //result = Regex.Replace(result, "[óòỏõọôốồổỗộơớờởỡợ]".ToUpper(), "O");

      //Giúp bỏ dấu tiếng việt
      result = result.Normalize(NormalizationForm.FormD);
      result = Regex.Replace(result, "\\p{IsCombiningDiacriticalMarks}+", String.Empty);
      result = result.Replace('\u0111', 'd').Replace('\u0110', 'D');

      return result;
    }

    /// <summary>
    /// Chuyển đổi giá trị value thành dạng Url
    /// trả về giá trị dạng Url
    /// </summary>
    /// <param name="value">Giá trị cần chuyển đổi</param>
    /// <param name="isTrim">Có tự động cắt khoảng trắng 2 đầu không? True: có; false: không
    /// </param><returns>Giá trị cần chuyển đổi</returns>
    public static string ToUrlFormat(this object value, bool isTrim = false)
    {
      if (value == null)
      {
        return string.Empty;
      }

      string result = value.ToString().ToLower();

      result = ToNoSignFormat(result, isTrim);
      result = result.Replace(" ", "-");
      return result;


    }

    /// <summary>
    /// Trích lọc từ bên trái của value một số kí tự.
    /// Trả về chuỗi mới đã trích lọc từ bên trái
    /// </summary>
    /// <param name="value">Giá trị cần trích lọc</param>
    /// <param name="lenght">Số kí tự cần lấy</param>
    /// <param name="isTrim">Có Trim không? true: có; false: không</param>
    /// /// <param name="hasThreeDots">Có thêm ... vào cuối không? true: có; false: không</param>
    /// <returns>Trả về chuỗi mới đã trích lọc từ bên trái</returns>
    public static string Left(this object value, int lenght, bool isTrim = false, bool hasThreeDots = false)
    {
      if (value == null || lenght < 0)
        return string.Empty;

      string result = value.ToString();

      if (isTrim)
        result = result.Trim();

      //Xử lý chiều dài kí tự tối đa
      int currentLengt = result.Length;
      //Nếu chiều dài cần lấy mà lớn hơn chiều dài hiện tại thì cho chiều dài cần lấy bằng chiều dài hiện tại
      if (lenght > currentLengt)
        lenght = currentLengt;

      result = result.Substring(0, lenght);

      if (isTrim)
        result = result.Trim();

      if (hasThreeDots && currentLengt > result.Length)
        result += "...";

      return result;
    }

    /// <summary>
    /// Trích lọc từ bên phải của value một số kí tự.
    /// Trả về chuỗi mới đã trích lọc từ bên phải
    /// </summary>
    /// <param name="value">Giá trị cần trích lọc</param>
    /// <param name="lenght">Số kí tự cần lấy</param>
    /// <param name="isTrim">Có Trim không? true: có; false: không</param>
    /// <param name="hasThreeDots">Có thêm ... vào đầu không? true: có; false: không</param>
    /// <returns>Trả về chuỗi mới đã trích lọc từ bên phải</returns>
    public static string Right(this object value, int lenght, bool isTrim = false, bool hasThreeDots = false)
    {
      if (value == null)
        return string.Empty;

      string result = value.ToString();

      if (isTrim)
        result = result.Trim();

      int CurrentLenght = result.Length;

      if (lenght > CurrentLenght)
        lenght = CurrentLenght;

      result = result.Substring(CurrentLenght - lenght, lenght);

      if (isTrim)
        result = result.Trim();

      if (hasThreeDots && !(CurrentLenght == lenght))
        result = "..." + result;
      return result;
    }

    public static string RemoveDoubleSpace(this string value)
    {
      value = Regex.Replace(value, @"\s+", " ");
      return value;
    }

    public static string ToUpperCase(this string value, bool removeDoubleSpace = true)
    {
      value = value.ToStringSafe();
      value = value.ToUpper();

      if (removeDoubleSpace)
        value = value.RemoveDoubleSpace();
      return value;
    }

    public static string ToLowerCase(this string value, bool removeDoubleSpace = true)
    {
      value = value.ToStringSafe();
      value = value.ToLower();

      if (removeDoubleSpace)
        value = value.RemoveDoubleSpace();
      return value;
    }

    public static string ToTitleCase(this string value, bool removeDoubleSpace = true)
    {
      value = value.ToLowerCase(removeDoubleSpace);

      TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
      value = textInfo.ToTitleCase(value);
      return value;
    }

    public static string ToNoSings(this string value, bool removeDoubleSpace = true)
    {
      Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
      value = value.ToStringSafe();
      value = value.Normalize(NormalizationForm.FormD);
      value = regex.Replace(value, String.Empty);
      value = value.Replace('\u0111', 'd').Replace('\u0110', 'D');
      if (removeDoubleSpace)
        value = value.RemoveDoubleSpace();
      return value;
    }

    public static string ToUrlFormat(this string value, bool removeSign = true, StringCaseType stringCaseType = StringCaseType.LowerCase)
    {
      //1. Chuyển chuỗi về dạng chuỗi không Null
      value = value.ToStringSafe();
      //2. Gỡ toàn bộ dấu nếu cần
      if (removeSign)
        value = value.ToNoSings(true);
      //3. Định nghĩa một danh sách các ký tự đặc biệt
      string specialChar = "@#$%^&()+-*/\\={}[]|:;'\"`“”<>.,?!_~";
      //4. Loại bỏ các ký tự đặc biệt
      foreach (char item in specialChar.ToCharArray())
      {
        value = value.Replace(item, ' ');
      }
      //5. Loại bỏ khoảng trắng kép
      value = value.RemoveDoubleSpace();
      //6. Chuyển đổi kiểu chữ hoa - thường
      switch (stringCaseType)
      {
        case StringCaseType.LowerCase:
          value = value.ToLowerCase(true);
          break;
        case StringCaseType.UpperCase:
          value = value.ToUpperCase(true);
          break;
        case StringCaseType.TitleCase:
          value = value.ToTitleCase(true);
          break;
        case StringCaseType.None:
        default:
          break;
      }
      //7. Thay khoảng trắng bằng dấu gạch ngang (-)
      value = value.Replace(' ', '-');
      //8. Loại bỏ dấu gạch ngang ở 2 đầu văn bản
      value = value.Trim('-');
      //9. Trả về kết quả
      return value;
    }

    /// <summary>
    /// Split string with priority is left or right
    /// </summary>
    /// <param name="value"></param>
    /// <param name="removeSign">True:Is remove sign of string value</param>
    /// <param name="stringCaseType">Convert type string is Lower, Upper or Normal</param>
    /// <param name="removeDoubleSpace">True: Is remove double space</param>
    /// <returns>Return string</returns>
    public static string SubStringWithLength(this string value, int length, bool removeSign = false, StringCaseType stringCaseType = StringCaseType.None, bool removeDoubleSpace = false)
    {
      //1. Chuyển chuỗi về dạng chuỗi không Null
      value = value.ToStringSafe();
      //2. Gỡ toàn bộ dấu nếu cần
      if (removeSign)
        value = value.ToNoSings(true);
      //5. Loại bỏ khoảng trắng kép nếu cần
      if (removeDoubleSpace)
        value = value.RemoveDoubleSpace();
      //6. Chuyển đổi kiểu chữ hoa - thường
      switch (stringCaseType)
      {
        case StringCaseType.LowerCase:
          value = value.ToLowerCase(true);
          break;
        case StringCaseType.UpperCase:
          value = value.ToUpperCase(true);
          break;
        case StringCaseType.TitleCase:
          value = value.ToTitleCase(true);
          break;
        case StringCaseType.None:
        default:
          break;
      }
      //7. Cắt chuỗi theo độ ưu tiên true:Left | false:Right
      if (value.Length > length)
      {
        int endIndex = value.IndexOf(" ", length);
        if (endIndex - length > 5)
        {
          endIndex = value.LastIndexOf(" ", 0, length);
        }
        value = value.Substring(0, endIndex);
        value += "...";
      }
      return value;

    }
  }

  public static class FileUtility
  {
    public static string ReadFile(string url, ref bool isSuccess, ref Exception error)
    {

      try
      {
        string result = File.ReadAllText(url);

        isSuccess = true;

        return result;
      }
      catch (Exception ex)
      {
        error = ex;

        isSuccess = false;

        return string.Empty;
      }
    }


    #region ReadFile
    /// <summary>
    /// Đọc nội dung file
    /// </summary>
    /// <param name="url">
    /// Đường dẫn đến file cần đọc
    /// </param>
    /// <returns>
    /// Trả về nội dung của file đọc được
    /// </returns>
    public static string ReadFile(string url)
    {
      //1. Khai báo biến chứa nội dung file
      string text = string.Empty;

      //2. Khai báo đối tượng đọc file
      StreamReader reader = new StreamReader(url);

      //3. Đọc nội dung file
      text = reader.ReadToEnd();

      //4. Thoát file
      reader.Close();

      //5. Trả về kết quả
      return text;
    }

    /// <summary>
    /// Đọc nội dung file
    /// </summary>
    /// <param name="url">
    /// Đường dẫn đến file cần đọc
    /// </param>
    /// <param name="error">
    /// Chứa lỗi ngoại lệ (nếu có) trong quá trình đọc file
    /// </param>
    /// <returns>
    /// Trả về nội dung của file đọc được
    /// </returns>
    /// <remarks>
    /// Nếu có lỗi ngoại lệ xảy ra, thì trả về String.Empty
    /// </remarks>
    public static string ReadFile(string url, ref Exception error)
    {
      //1. Khai báo biến chứa nội dung file
      string text = string.Empty;

      try
      {
        //2. Khai báo đối tượng đọc file
        StreamReader reader = new StreamReader(url);

        //3. Đọc nội dung file
        text = reader.ReadToEnd();

        //4. Thoát file
        reader.Close();
      }
      catch (Exception ex)
      {
        //Xuất lỗi bắt được (ex) ra ngoài hàm theo biến (error)
        error = ex;
        //Trả về rỗng
        return string.Empty;
      }

      //5. Trả về kết quả
      return text;
    }
    #endregion

    #region WriteFile
    /// <summary>
    /// Ghi nội dung vào file
    /// </summary>
    /// <param name="url">
    /// Đường dẫn đến vị trí file sẽ được ghi
    /// </param>
    /// <param name="text">
    /// Nội dung sẽ ghi vào file
    /// </param>
    /// <returns>
    /// Nếu ghi file thành công, trả về true; ngược lại, trả về false
    /// </returns>
    public static bool WriteFile(string url, string text)
    {
      //1. Khai báo biến chứa kết quả
      bool result = false;

      //2. Khai báo đối tượng ghi file
      StreamWriter writer = new StreamWriter(url);

      //3. Ghi file
      writer.Write(text);

      //4. Thoát file
      writer.Close();

      //5. Cho kết quả bằng true (đã ghi file)
      result = true;

      //6. Trả về kết quả
      return result;
    }

    /// <summary>
    /// Ghi nội dung vào file
    /// </summary>
    /// <param name="url">
    /// Đường dẫn đến vị trí file sẽ được ghi
    /// </param>
    /// <param name="text">
    /// Nội dung sẽ ghi vào file
    /// </param>
    /// <param name="error">
    /// Chứa lỗi ngoại lệ (nếu có) trong quá trình ghi file
    /// </param>
    /// <returns>
    /// Nếu ghi file thành công, trả về true; ngược lại, trả về false
    /// </returns>
    /// <remarks>
    /// Nếu có lỗi ngoại lệ xảy ra, thì trả về False
    /// </remarks>
    public static bool WriteFile(string url, string text, ref Exception error)
    {
      //1. Khai báo biến chứa kết quả
      bool result = false;

      try
      {
        //2. Khai báo đối tượng ghi file
        StreamWriter writer = new StreamWriter(url);

        //3. Ghi file
        writer.Write(text);

        //4. Thoát file
        writer.Close();
      }
      catch (Exception ex)
      {
        //Xuất lỗi bắt được (ex) ra ngoài hàm theo biến (error)
        error = ex;
        //Trả về false (chưa ghi file)
        return false;
      }

      //5. Cho kết quả bằng true (đã ghi file)
      result = true;

      //6. Trả về kết quả
      return result;
    }
    #endregion

    #region ManagementFile

    /// <summary>
    /// Kiểm tra sự tồn tại của một file tại url.
    /// Nếu file có tồn tại: trả về true; ngược lại trả về false.
    /// Nếu url là null, empty hoặc không hợp lệ, kết quả trả về là false.
    /// </summary>
    /// <param name="url">Đường dẫn đến file cần kiểm tra tồn tại.</param>
    /// <returns>Nếu file có tồn tại: trả về true; ngược lại trả về false.</returns>
    public static bool IsExists(string url)
    {
      return File.Exists(url);
    }

    /// <summary>
    /// Tính tổng dung lượng của một file tại url. Đơn vị tính là kilobyte.
    /// Nếu url không tồn tại, trả về 0.
    /// </summary>
    /// <param name="url">Đường dẫn đến file cần tính dung lượng.</param>
    /// <param name="searchOption">Có 2 tùy chọn: TopDirectoryOnly: chỉ xét trong file hiện tại; AllDirectories: Bao gồm file hiện tại và mọi file con bên trong.</param>
    /// <returns>Trả về tổng dung lượng của một file. Đơn vị tính là kilobyte.</returns>
    public static long GetSize(string url)
    {
      //1. Kiểm tra nếu file tại url không tồn tại thì trả về 0
      if (!IsExists(url))
        return 0;

      //2. Tạo một biến để chứa dung lượng
      long size = 0;

      //3. Load file từ url
      FileInfo file = new FileInfo(url);

      //4. Tính dung lượng của file
      size = file.Length;

      //5. Trả về kết quả
      return size;
    }

    /// <summary>
    /// Di chuyển một file từ url đến newUrl. Có bắt lỗi ngoại lệ (nếu có).
    /// Nếu di chuyển thành công: trả về true; ngược lại trả về false.
    /// Nếu có lỗi ngoại lệ xảy ra thì trả về false.
    /// </summary>
    /// <param name="url">Đường dẫn đến file cần chuyển đi. Ví dụ: C:\Images\abc.txt</param>
    /// <param name="newUrl">Đường dẫn đến file cần chuyển đến. Ví dụ: C:\Document\Images\abc.txt</param>
    /// <param name="error">Chứa lỗi ngoại lệ (nếu có) trong quá trình di chuyển file.</param>
    /// <returns>Nếu di chuyển thành công: trả về true; ngược lại trả về false.</returns>
    public static bool Move(string url, string newUrl, ref Exception error)
    {
      //1. Kiểm tra nếu file tại url không tồn tại thì trả về false
      if (!IsExists(url))
      {
        string message = string.Format("The file with path is not exist: {0}", url);
        error = new Exception(message);
        return false;
      }

      //2. Load file từ url
      FileInfo file = new FileInfo(url);

      try
      {
        //3. Di chuyển file sang newUrl
        file.MoveTo(newUrl);
      }
      catch (Exception ex)
      {
        error = ex;
        return false;
      }

      //4. Trả về kết quả thành công
      return true;
    }

    /// <summary>
    /// Đổi tên một file sang tên mới. Có bắt lỗi ngoại lệ (nếu có).
    /// Nếu đổi tên thành công: trả về true; ngược lại trả về false.
    /// Nếu có lỗi ngoại lệ xảy ra thì trả về false.
    /// </summary>
    /// <param name="url">Đường dẫn đến file cần đổi tên. Ví dụ: C:\Images\abc.txt</param>
    /// <param name="newName">Tên mới của file. Ví dụ: bcd.txt</param>
    /// <param name="error">Chứa lỗi ngoại lệ (nếu có) trong quá trình đổi tên file.</param>
    /// <returns>Nếu đổi tên thành công: trả về true; ngược lại trả về false.</returns>
    public static bool Rename(string url, string newName, ref Exception error)
    {
      //1. Kiểm tra nếu file tại url không tồn tại thì trả về false
      if (!IsExists(url))
      {
        string message = string.Format("The file with path is not exist: {0}", url);
        error = new Exception(message);
        return false;
      }

      //2. Load file từ url
      FileInfo file = new FileInfo(url);

      //3. Load folder cha của url
      DirectoryInfo parentFolder = file.Directory;

      //4. Tạo url với tên mới
      string newUrl = Path.Combine(parentFolder.FullName, newName);

      //5. Di chuyển file từ url sang newUrl
      return Move(url, newUrl, ref error);
    }

    /// <summary>
    /// Xóa một file. Có bắt lỗi ngoại lệ (nếu có).
    /// Nếu xóa thành công hoặc file không tồn tại: trả về true; ngược lại trả về false.
    /// Nếu có lỗi ngoại lệ xảy ra thì trả về false.
    /// </summary>
    /// <param name="url">Đường dẫn đến file cần xóa. Ví dụ: C:\Images\abc.txt</param>
    /// <param name="error">Chứa lỗi ngoại lệ (nếu có) trong quá trình xóa file.</param>
    /// <returns>Nếu xóa thành công hoặc file không tồn tại: trả về true; ngược lại trả về false.</returns>
    public static bool Delete(string url, ref Exception error)
    {
      //1. Kiểm tra nếu file tại url không tồn tại thì trả về true
      if (!IsExists(url))
      {
        return true;
      }

      //2. Load file từ url
      FileInfo file = new FileInfo(url);

      try
      {
        //3. Xóa file
        file.Delete();
      }
      catch (Exception ex)
      {
        error = ex;
        return false;
      }

      //4. Trả về kết quả thành công
      return true;
    }

    #endregion

  }

  public class MailUtility
  {
    #region Properties
    private string _From = string.Empty;
    /// <summary>
    /// Trả về hoặc thiết lập địa chỉ gửi.
    /// VD: nguoigui@gmail.com
    /// </summary>
    public string From
    {
      get
      {
        return _From;
      }
      set
      {
        _From = value;
      }
    }

    private string _Password = string.Empty;
    /// <summary>
    /// Trả về hoặc thiết lập mật khẩu gửi
    /// </summary>
    public string Password
    {
      get
      {
        return _Password;
      }
      set
      {
        _Password = value;
      }
    }

    private string _Host = string.Empty;
    /// <summary>
    /// Trả về hoặc thiết lập địa chỉ máy chủ gửi.
    /// VD: smpt.gmail.com
    /// </summary>
    public string Host
    {
      get
      {
        return _Host;
      }
      set
      {
        _Host = value;
      }
    }

    private int _Port = 0;
    /// <summary>
    /// Trả về hoặc thiết lập cổng dùng để gửi.
    /// Mặc định cổng của gmail là: 587
    /// </summary>
    public int Port
    {
      get
      {
        return _Port;
      }
      set
      {
        _Port = value;
      }
    }

    private bool _EnableSSL = false;
    /// <summary>
    /// Trả về hoặc thiết lập cơ chế bảo mật SSL.
    /// Thiết lập là true nếu dùng gmail để gửi
    /// </summary>
    public bool EnableSSL
    {
      get
      {
        return _EnableSSL;
      }
      set
      {
        _EnableSSL = value;
      }
    }

    private string _To = string.Empty;
    /// <summary>
    /// Trả về hoặc thiết lập địa chỉ nhận
    /// VD: nguoinhan@gmail.com
    /// </summary>
    public string To
    {
      get
      {
        return _To;
      }
      set
      {
        _To = value;
      }
    }

    private string _Subject = string.Empty;
    /// <summary>
    /// Trả về hoặc thiết lập chủ đề của thư
    /// </summary>
    public string Subject
    {
      get
      {
        return _Subject;
      }
      set
      {
        _Subject = value;
      }
    }

    private string _Body = string.Empty;
    /// <summary>
    /// Trả về hoặc thiết lập nội dung của thư
    /// </summary>
    public string Body
    {
      get
      {
        return _Body;
      }
      set
      {
        _Body = value;
      }
    }

    private bool _IsBodyHtml = false;
    /// <summary>
    /// Trả về hoặc thiết lập cấu hình sử dụng mã HTML trong nội dung thư
    /// </summary>
    public bool IsBodyHtml
    {
      get
      {
        return _IsBodyHtml;
      }
      set
      {
        _IsBodyHtml = value;
      }
    }

    private string _CC = string.Empty;
    /// <summary>
    /// Trả về hoặc thiết lập địa chỉ CC.
    /// VD: chiase@gmail.com
    /// </summary>
    public string CC
    {
      get
      {
        return _CC;
      }
      set
      {
        _CC = value;
      }
    }

    private string _BCC = string.Empty;
    /// <summary>
    /// Trả về hoặc thiết lập địa chỉ BCC.
    /// VD: chiasean@gmail.com
    /// </summary>
    public string BCC
    {
      get
      {
        return _BCC;
      }
      set
      {
        _BCC = value;
      }
    }

    private string _AttachmentFile = string.Empty;
    /// <summary>
    /// Trả về hoặc thiết lập đường dẫn đến file đính kèm
    /// VD: C:\demo\file.txt
    /// </summary>
    public string AttachmentFile
    {
      get
      {
        return _AttachmentFile;
      }
      set
      {
        _AttachmentFile = value;
      }
    }

    private Exception _LastException = null;
    /// <summary>
    /// Trả về hoặc thiết lập lỗi ngoại lệ cuối cùng
    /// </summary>
    public Exception LastException
    {
      get
      {
        return _LastException;
      }
      set
      {
        _LastException = value;
      }
    }
    #endregion

    #region StaticMethods
    /// <summary>
    /// Gửi email
    /// </summary>
    /// <param name="from">Địa chỉ gửi</param>
    /// <param name="password">Mật khẩu gửi</param>
    /// <param name="host">Địa chỉ máy chủ</param>
    /// <param name="port">Cổng máy chủ</param>
    /// <param name="enableSSL">True: thiết lập bảo mật SSL; False: không bảo mật</param>
    /// <param name="to">Địa chỉ người nhận</param>
    /// <param name="subject">Chủ đề của thư</param>
    /// <param name="body">Nội dung thư</param>
    /// <param name="isBodyHtml">True: có chứa định dạng HTML; False: không chứa định dạng HTML</param>
    /// <returns>True: đã gửi thư; False: không thể gửi thư</returns>
    public static bool Send(string from, string password, string host, int port, bool enableSSL, string to, string subject, string body, bool isBodyHtml)
    {
      Exception error = null;
      return Send(from, password, host, port, enableSSL, to, subject, body, isBodyHtml, string.Empty, string.Empty, string.Empty, ref error);
    }

    /// <summary>
    /// Gửi email có CC
    /// </summary>
    /// <param name="from">Địa chỉ gửi</param>
    /// <param name="password">Mật khẩu gửi</param>
    /// <param name="host">Địa chỉ máy chủ</param>
    /// <param name="port">Cổng máy chủ</param>
    /// <param name="enableSSL">True: thiết lập bảo mật SSL; False: không bảo mật</param>
    /// <param name="to">Địa chỉ người nhận</param>
    /// <param name="subject">Chủ đề của thư</param>
    /// <param name="body">Nội dung thư</param>
    /// <param name="isBodyHtml">True: có chứa định dạng HTML; False: không chứa định dạng HTML</param>
    /// <param name="cc">Địa chỉ CC. Thiết lập cc là rỗng nếu không muốn CC</param>
    /// <returns>True: đã gửi thư; False: không thể gửi thư</returns>
    public static bool Send(string from, string password, string host, int port, bool enableSSL, string to, string subject, string body, bool isBodyHtml, string cc)
    {
      Exception error = null;
      return Send(from, password, host, port, enableSSL, to, subject, body, isBodyHtml, cc, string.Empty, string.Empty, ref error);
    }

    /// <summary>
    /// Gửi email có CC và BCC
    /// </summary>
    /// <param name="from">Địa chỉ gửi</param>
    /// <param name="password">Mật khẩu gửi</param>
    /// <param name="host">Địa chỉ máy chủ</param>
    /// <param name="port">Cổng máy chủ</param>
    /// <param name="enableSSL">True: thiết lập bảo mật SSL; False: không bảo mật</param>
    /// <param name="to">Địa chỉ người nhận</param>
    /// <param name="subject">Chủ đề của thư</param>
    /// <param name="body">Nội dung thư</param>
    /// <param name="isBodyHtml">True: có chứa định dạng HTML; False: không chứa định dạng HTML</param>
    /// <param name="cc">Địa chỉ CC. Thiết lập cc là rỗng nếu không muốn CC</param>
    /// <param name="bcc">Địa chỉ BCC. Thiết lập bcc là rỗng nếu không muốn BCC</param>
    /// <returns>True: đã gửi thư; False: không thể gửi thư</returns>
    public static bool Send(string from, string password, string host, int port, bool enableSSL, string to, string subject, string body, bool isBodyHtml, string cc, string bcc)
    {
      Exception error = null;
      return Send(from, password, host, port, enableSSL, to, subject, body, isBodyHtml, cc, bcc, string.Empty, ref error);
    }

    /// <summary>
    /// Gửi email có CC, BCC và file đính kèm
    /// </summary>
    /// <param name="from">Địa chỉ gửi</param>
    /// <param name="password">Mật khẩu gửi</param>
    /// <param name="host">Địa chỉ máy chủ</param>
    /// <param name="port">Cổng máy chủ</param>
    /// <param name="enableSSL">True: thiết lập bảo mật SSL; False: không bảo mật</param>
    /// <param name="to">Địa chỉ người nhận</param>
    /// <param name="subject">Chủ đề của thư</param>
    /// <param name="body">Nội dung thư</param>
    /// <param name="isBodyHtml">True: có chứa định dạng HTML; False: không chứa định dạng HTML</param>
    /// <param name="cc">Địa chỉ CC. Thiết lập cc là rỗng nếu không muốn CC</param>
    /// <param name="bcc">Địa chỉ BCC. Thiết lập bcc là rỗng nếu không muốn BCC</param>
    /// <param name="attachmentFile">File đính kèm. Thiết lập attachmentFile là rỗng nếu không muốn gửi file đính kèm</param>
    /// <returns>True: đã gửi thư; False: không thể gửi thư</returns>
    public static bool Send(string from, string password, string host, int port, bool enableSSL, string to, string subject, string body, bool isBodyHtml, string cc, string bcc, string attachmentFile)
    {
      Exception error = null;
      return Send(from, password, host, port, enableSSL, to, subject, body, isBodyHtml, cc, bcc, attachmentFile, ref error);
    }

    /// <summary>
    /// Gửi email có CC, BCC, file đính kèm và bắt lỗi ngoại lệ
    /// </summary>
    /// <param name="from">Địa chỉ gửi</param>
    /// <param name="password">Mật khẩu gửi</param>
    /// <param name="host">Địa chỉ máy chủ</param>
    /// <param name="port">Cổng máy chủ</param>
    /// <param name="enableSSL">True: thiết lập bảo mật SSL; False: không bảo mật</param>
    /// <param name="to">Địa chỉ người nhận</param>
    /// <param name="subject">Chủ đề của thư</param>
    /// <param name="body">Nội dung thư</param>
    /// <param name="isBodyHtml">True: có chứa định dạng HTML; False: không chứa định dạng HTML</param>
    /// <param name="cc">Địa chỉ CC. Thiết lập cc là rỗng nếu không muốn CC</param>
    /// <param name="bcc">Địa chỉ BCC. Thiết lập bcc là rỗng nếu không muốn BCC</param>
    /// <param name="attachmentFile">File đính kèm. Thiết lập attachmentFile là rỗng nếu không muốn gửi file đính kèm</param>
    /// <param name="error">Chứa lỗi ngoại lệ bắt được trong quá trình gửi mail</param>
    /// <returns>True: đã gửi thư; False: không thể gửi thư</returns>
    public static bool Send(string from, string password, string host, int port, bool enableSSL, string to, string subject, string body, bool isBodyHtml, string cc, string bcc, string attachmentFile, ref Exception error)
    {
      MailMessage mail = new MailMessage();

      SmtpClient smtp = new SmtpClient();

      NetworkCredential credential = new NetworkCredential();

      mail.From = new MailAddress(from);
      mail.To.Add(to);
      mail.Subject = subject;
      mail.Body = body;
      mail.IsBodyHtml = isBodyHtml;
      if (cc != string.Empty)
        mail.CC.Add(cc);
      if (bcc != string.Empty)
        mail.Bcc.Add(bcc);
      if (attachmentFile != string.Empty)
        mail.Attachments.Add(new Attachment(attachmentFile));

      credential.UserName = from;
      credential.Password = password;

      smtp.Host = host;
      smtp.Port = port;
      smtp.EnableSsl = enableSSL;
      smtp.Credentials = credential;

      try
      {
        smtp.Send(mail);
      }
      catch (Exception ex)
      {
        error = ex;
        return false;
      }

      return true;
    }

    /// <summary>
    /// Gửi email theo mẫu có CC, BCC, file đính kèm và bắt lỗi ngoại lệ
    /// </summary>
    /// <param name="from">Địa chỉ gửi</param>
    /// <param name="password">Mật khẩu gửi</param>
    /// <param name="host">Địa chỉ máy chủ</param>
    /// <param name="port">Cổng máy chủ</param>
    /// <param name="enableSSL">True: thiết lập bảo mật SSL; False: không bảo mật</param>
    /// <param name="to">Địa chỉ người nhận</param>
    /// <param name="subject">Chủ đề của thư</param>
    /// <param name="templateUrl">Đường dẫn đến file mẫu. VD: C:\EmailMau.txt</param>
    /// <param name="param">Tham số dùng để thay thế trong file mẫu</param>
    /// <param name="isBodyHtml">True: có chứa định dạng HTML; False: không chứa định dạng HTML</param>
    /// <param name="cc">Địa chỉ CC. Thiết lập cc là rỗng nếu không muốn CC</param>
    /// <param name="bcc">Địa chỉ BCC. Thiết lập bcc là rỗng nếu không muốn BCC</param>
    /// <param name="attachmentFile">File đính kèm. Thiết lập attachmentFile là rỗng nếu không muốn gửi file đính kèm</param>
    /// <param name="error">Chứa lỗi ngoại lệ bắt được trong quá trình gửi mail</param>
    /// <returns>True: đã gửi thư; False: không thể gửi thư</returns>
    public static bool SendWithTemplate(string from, string password, string host, int port, bool enableSSL, string to, string subject, string templateUrl, Dictionary<string, string> param, bool isBodyHtml, string cc, string bcc, string attachmentFile, ref Exception error)
    {
      //1. Đọc nội dung từ file template
      string body = FileUtility.ReadFile(templateUrl, ref error);

      //2. Kiểm tra lỗi khi đọc file template
      if (error != null)
        return false;

      //3. Thay thế các giá trị lưu trong từ điển
      foreach (var item in param)
      {
        body = body.Replace(item.Key, item.Value);
      }

      //4. Gửi thư
      return MailUtility.Send(from, password, host, port, enableSSL, to, subject, body, isBodyHtml, cc, bcc, attachmentFile, ref error);
    }

    #endregion

    #region Methods
    /// <summary>
    /// Gửi email
    /// </summary>
    /// <param name="from">Địa chỉ gửi</param>
    /// <param name="password">Mật khẩu gửi</param>
    /// <param name="host">Địa chỉ máy chủ</param>
    /// <param name="port">Cổng máy chủ</param>
    /// <param name="enableSSL">True: thiết lập bảo mật SSL; False: không bảo mật</param>
    /// <param name="to">Địa chỉ người nhận</param>
    /// <param name="subject">Chủ đề của thư</param>
    /// <param name="body">Nội dung thư</param>
    /// <param name="isBodyHtml">True: có chứa định dạng HTML; False: không chứa định dạng HTML</param>
    /// <returns>True: đã gửi thư; False: không thể gửi thư</returns>
    public bool Send()
    {
      Exception error = null;
      bool result = MailUtility.Send(this.From, this.Password, this.Host, this.Port, this.EnableSSL, this.To, this.Subject, this.Body, this.IsBodyHtml, this.CC, this.BCC, this.AttachmentFile, ref error);
      this.LastException = error;

      return result;
    }

    /// <summary>
    /// Gửi email
    /// </summary>
    /// <param name="from">Địa chỉ gửi</param>
    /// <param name="password">Mật khẩu gửi</param>
    /// <param name="host">Địa chỉ máy chủ</param>
    /// <param name="port">Cổng máy chủ</param>
    /// <param name="enableSSL">True: thiết lập bảo mật SSL; False: không bảo mật</param>
    /// <param name="to">Địa chỉ người nhận</param>
    /// <param name="subject">Chủ đề của thư</param>
    /// <param name="body">Nội dung thư</param>
    /// <param name="isBodyHtml">True: có chứa định dạng HTML; False: không chứa định dạng HTML</param>
    /// <returns>True: đã gửi thư; False: không thể gửi thư</returns>
    public bool SendWithTemplate(string templateUrl, Dictionary<string, string> param)
    {
      Exception error = null;
      bool result = MailUtility.SendWithTemplate(this.From, this.Password, this.Host, this.Port, this.EnableSSL, this.To, this.Subject, templateUrl, param, this.IsBodyHtml, this.CC, this.BCC, this.AttachmentFile, ref error);
      this.LastException = error;

      return result;
    }
    #endregion
  }

  public static class Enums
  {
    public enum FitSizeType
    {
      Width = 1,
      Height = 2
    }

    public enum WaterMaskPositionType
    {
      MiddleCenter = 0,
      TopLeft = 1,
      TopRight = 2,
      BottomLeft = 3,
      BottomRight = 4
    }

    public enum StringCaseType
    {
      None = 0,
      UpperCase = 1,
      LowerCase = 2,
      TitleCase = 3
    }
  }

  public static class SecurityUtility
  {
    public static string ToMD5(this string value)
    {
      //Tạo MD5
      MD5 md5 = MD5.Create();

      //Chuyển kiểu chuổi thành kiểu byte
      byte[] inputBytes = Encoding.ASCII.GetBytes(value);

      //mã hóa chuỗi đã chuyển
      byte[] hashBytes = md5.ComputeHash(inputBytes);

      //tạo đối tượng StringBuilder (làm việc với kiểu dữ liệu lớn)
      StringBuilder stringBuilder = new StringBuilder();

      for (int i = 0; i < hashBytes.Length; i++)
      {
        stringBuilder.Append(hashBytes[i].ToString("X2"));
        //Nếu muốn giá trị là chữ thường, thay X2 thành x2
      }
      return stringBuilder.ToString();
    }

    public static string ToMD5(this string value, string salt)
    {
      string newValue = value + salt;
      return ToMD5(newValue);
    }

    public static string ToSHA256(this string value)
    {
      //Khai báo chuỗi chứa kết quả
      StringBuilder stringBuilder = new StringBuilder();

      //Khai báo đối tượng hỗ trợ băm theo hàm SHA256
      SHA256 hash = SHA256.Create();

      //Khai báo bảng mã sẽ sử dụng
      Encoding encoding = Encoding.UTF8;

      //Chuyển giá trị đầu vào thành mảng byte
      byte[] inputBytes = encoding.GetBytes(value);

      //Băm mảng byte đầu vào
      Byte[] result = hash.ComputeHash(inputBytes);

      //Thu hồi đối tượng băm
      hash.Dispose();

      //Xử lý kết quả
      foreach (Byte Byte in result)
        stringBuilder.Append(Byte.ToString("x2"));
      //Trả về kết quả
      return stringBuilder.ToString();
    }

    public static string ToSHA256(this string value, string salt)
    {
      string newValue = value + salt;
      return ToSHA256(newValue);
    }

    public static string ToSHA512(this string value)
    {
      //Khai báo chuỗi chứa kết quả
      StringBuilder stringBuilder = new StringBuilder();

      //Khai báo đối tượng hỗ trợ băm theo hàm SHA256
      SHA512 hash = SHA512.Create();

      //Khai báo bảng mã sẽ sử dụng
      Encoding encoding = Encoding.UTF8;

      //Chuyển giá trị đầu vào thành mảng byte
      byte[] inputBytes = encoding.GetBytes(value);

      //Băm mảng byte đầu vào
      Byte[] result = hash.ComputeHash(inputBytes);

      //Thu hồi đối tượng băm
      hash.Dispose();

      //Xử lý kết quả
      foreach (Byte Byte in result)
        stringBuilder.Append(Byte.ToString("x2"));
      //Trả về kết quả
      return stringBuilder.ToString();
    }

    public static string ToSHA512(this string value, string salt)
    {
      string newValue = value + salt;
      return ToSHA512(newValue);
    }

    #region Url
    /// <summary>
    /// Mã hóa Url.
    /// Trả về giá trị sau khi được mã hóa.
    /// </summary>
    /// <param name="value">Giá trị cần mã hóa.</param>
    /// <returns>Trả về giá trị sau khi được mã hóa.</returns>
    public static string UrlEncode(string value)
    {
      return WebUtility.UrlEncode(value);
    }

    /// <summary>
    /// Giải mã Url.
    /// Trả về giá trị sau khi được giải mã.
    /// </summary>
    /// <param name="value">Giá trị cần giãi mã.</param>
    /// <returns>Trả về giá trị sau khi được giải mã.</returns>
    public static string UrlDecode(string value)
    {
      return WebUtility.UrlDecode(value);
    }
    #endregion

    #region Html
    /// <summary>
    /// Mã hóa Html.
    /// Trả về giá trị sau khi được mã hóa.
    /// </summary>
    /// <param name="value">Giá trị cần mã hóa.</param>
    /// <returns>Trả về giá trị sau khi được mã hóa.</returns>
    public static string HtmlEncode(string value)
    {
      return WebUtility.HtmlEncode(value);
    }

    /// <summary>
    /// Giải mã Html.
    /// Trả về giá trị sau khi được giải mã.
    /// </summary>
    /// <param name="value">Giá trị cần giải mã.</param>
    /// <returns>Trả về giá trị sau khi được giải mã.</returns>
    public static string HtmlDecode(string value)
    {
      return WebUtility.HtmlDecode(value);
    }
    #endregion

    #region Encrypt
    /// <summary>
    /// Mã hóa dùng thuật toán băm MD5.
    /// Trả về giá trị sau khi được mã hóa có chiều dài cố định là 32 ký tự.
    /// </summary>
    /// <param name="value">Giá trị cần mã hóa.</param>
    /// <returns>Trả về giá trị sau khi được mã hóa có chiều dài cố định là 32 ký tự.</returns>
    public static string MD5Encrypt(string value)
    {
      //1. Nếu value = null hoặc empty thì trả về rỗng
      if (string.IsNullOrEmpty(value))
        return string.Empty;

      //2. Chuyển value về dạng byte[] UTF8
      byte[] byteArray = Encoding.UTF8.GetBytes(value);

      //3. Tạo đối tượng hỗ trợ mã hóa MD5
      MD5 md5 = new MD5CryptoServiceProvider();

      //4. Mã hóa MD5
      byte[] md5Value = md5.ComputeHash(byteArray);

      //5. Chuyển byte[] về dạng String
      string result = BitConverter.ToString(md5Value);

      //6. Gỡ bỏ cách dấu phân cách
      result = result.Replace("-", string.Empty);

      //7. Trả về kết quả
      return result;
    }

    /// <summary>
    /// Mã hóa dùng thuật toán băm MD5 kết hợp với salt.
    /// Trả về giá trị sau khi được mã hóa có chiều dài cố định là 32 ký tự.
    /// </summary>
    /// <param name="value">Giá trị cần mã hóa.</param>
    /// <param name="salt">Giá trị dùng làm khóa mã hóa</param>
    /// <returns>Trả về giá trị sau khi được mã hóa có chiều dài cố định là 32 ký tự.</returns>
    public static string MD5Encrypt(string value, string salt)
    {
      //1. Nếu value = null hoặc empty thì trả về rỗng
      if (string.IsNullOrEmpty(value))
      {
        return string.Empty;
      }

      //2. Thêm mật mã vào đầu giá trị cần mã hóa
      value = salt + value;

      //3. Mã hóa và trả về kết quả
      return MD5Encrypt(value);
    }

    /// <summary>
    /// Mã hóa dùng thuật toán băm SHA256.
    /// Trả về giá trị sau khi được mã hóa có chiều dài cố định là 64 ký tự.
    /// </summary>
    /// <param name="value">Giá trị cần mã hóa.</param>
    /// <returns>Trả về giá trị sau khi được mã hóa có chiều dài cố định là 64 ký tự.</returns>
    public static string SHA256Encrypt(string value)
    {
      //1. Nếu value = null hoặc empty thì trả về rỗng
      if (string.IsNullOrEmpty(value))
        return string.Empty;

      //2. Chuyển value về dạng byte[] UTF8
      byte[] byteArray = Encoding.UTF8.GetBytes(value);

      //3. Tạo đối tượng hỗ trợ mã hóa SHA256
      SHA256 sha256 = new SHA256CryptoServiceProvider();

      //4. Mã hóa SHA256
      byte[] sha256Value = sha256.ComputeHash(byteArray);

      //5. Chuyển byte[] về dạng String
      string result = BitConverter.ToString(sha256Value);

      //6. Gỡ bỏ cách dấu phân cách
      result = result.Replace("-", string.Empty);

      //7. Trả về kết quả
      return result;
    }

    /// <summary>
    /// Mã hóa dùng thuật toán băm SHA256 kết hợp với salt.
    /// Trả về giá trị sau khi được mã hóa có chiều dài cố định là 64 ký tự.
    /// </summary>
    /// <param name="value">Giá trị cần mã hóa.</param>
    /// <param name="salt">Giá trị dùng làm khóa mã hóa</param>
    /// <returns>Trả về giá trị sau khi được mã hóa có chiều dài cố định là 64 ký tự.</returns>
    public static string SHA256Encrypt(string value, string salt)
    {
      //1. Nếu value = null hoặc empty thì trả về rỗng
      if (string.IsNullOrEmpty(value))
      {
        return string.Empty;
      }

      //2. Thêm mật mã vào đầu giá trị cần mã hóa
      value = salt + value;

      //3. Mã hóa và trả về kết quả
      return SHA256Encrypt(value);
    }

    /// <summary>
    /// Mã hóa dữ liệu với thuật toán AES256.
    /// Trả về giá trị sau khi được mã hóa.
    /// </summary>
    /// <param name="value">Giá trị cần mã hóa.</param>
    /// <param name="password">Mật khẩu dùng để mã hóa</param>
    /// <param name="salt">Giá trị dùng làm khóa mã hóa</param>
    /// <returns>Trả về giá trị sau khi được mã hóa.</returns>
    public static string AES256Encrypt(string value, string password, string salt)
    {
      //1. Nếu value = null hoặc empty thì trả về rỗng
      if (string.IsNullOrEmpty(value))
        return string.Empty;

      //2. Chuyển value về dạng byte[] UTF8
      byte[] byteArray = UnicodeEncoding.Unicode.GetBytes(value);

      //3. Tạo fullPassword bằng cách kết hợp password và salt với nhau
      string fullPassword = password + salt;

      //4. Băm fullPassword bằng thuật toán SHA256
      SHA256 sha256 = SHA256.Create();
      byte[] key = sha256.ComputeHash(UnicodeEncoding.Unicode.GetBytes(fullPassword));

      //5. Tạo đối tượng hỗ trợ mã hóa AES
      Aes aes = new AesCryptoServiceProvider();

      //6. Thiết lập mã hóa với kích thước 256 bit
      aes.KeySize = 256;

      //7. Thiết lập key
      aes.Key = key;

      //8. Phát sinh ngẫu nhiên một Vector mã hóa IV dựa trên fullPassword
      aes.GenerateIV();

      //9. Khởi tạo bộ mã hóa từ đối tượng hỗ trợ mã hóa
      ICryptoTransform encryptor = aes.CreateEncryptor();

      //10. Mã hóa dữ liệu
      byte[] secureBytes = encryptor.TransformFinalBlock(byteArray, 0, byteArray.Length);

      //11.Nối Vector IV vào phần đầu của dữ liệu đã mã hóa
      secureBytes = aes.IV.Concat(secureBytes).ToArray();

      //12.Chuyển byte[] về dạng String
      string result = Convert.ToBase64String(secureBytes);

      //13.Trả về kết quả
      return result;
    }

    /// <summary>
    /// Giải mã dữ liệu với thuật toán AES256.
    /// Trả về giá trị sau khi được giải mã.
    /// </summary>
    /// <param name="value">Giá trị đã mã hóa cần được giải mã.</param>
    /// <param name="password">Mật khẩu dùng để giải hóa</param>
    /// <param name="salt">Giá trị dùng làm khóa giải hóa</param>
    /// <returns>Trả về giá trị sau khi được giải mã.</returns>
    public static string AES256Decrypt(string value, string password, string salt)
    {
      //1. Nếu value = null hoặc empty thì trả về rỗng
      if (string.IsNullOrEmpty(value))
      {
        return string.Empty;
      }

      //2. Chuyển value về dạng byte[] Unicode
      byte[] byteArray = Convert.FromBase64String(value);

      //3. Tạo fullPassword bằng cách kết hợp password và salt với nhau
      string fullPassword = password + salt;

      //4. Băm fullPassword bằng thuật toán SHA256
      SHA256 sha256 = SHA256.Create();
      byte[] key = sha256.ComputeHash(UnicodeEncoding.Unicode.GetBytes(fullPassword));

      //5. Tạo đối tượng hỗ trợ mã hóa AES
      Aes aes = new AesCryptoServiceProvider();

      //6. Thiết lập mã hóa với kích thước 256 bit
      aes.KeySize = 256;

      //7. Thiết lập key
      aes.Key = key;

      //8. Kiểm tra tính hợp lệ của IV
      if (byteArray.Length < 16)
        return string.Empty;

      //9. Trích lọc Vector IV từ 16 bit đầu của dữ liệu mã hóa
      aes.IV = byteArray.Take(16).ToArray();

      //10. Khởi tạo bộ mã hóa từ đối tượng hỗ trợ mã hóa
      ICryptoTransform decryptor = aes.CreateDecryptor();

      //11. Tạo đối tượng chứa kết quả
      byte[] result = null;

      try
      {
        //12. Giải mã dữ liệu sau khi đã trích lọc Vector IV
        result = decryptor.TransformFinalBlock(byteArray, 16, byteArray.Length - 16);
      }
      catch (Exception)
      {
        return string.Empty;
      }

      //13. Trả về kết quả
      return UnicodeEncoding.Unicode.GetString(result);
    }
    #endregion

  }

  public static class ValidationUtility
  {
    /// <summary>
    /// Kiểm tra giá trị value có Null không?
    /// Nếu value là Null, trả về true; ngược lại, trả về false.
    /// </summary>
    /// <param name="value">Giá trị cần kiểm tra.</param>
    /// <returns>Nếu value là Null, trả về true; ngược lại, trả về false.</returns>
    public static bool IsNull(this object value)
    {
      //Nếu value = null
      if (value == null)
        //Trả về true
        return true;
      //Ngược lại
      else
        //Trả về false
        return false;
    }

    /// <summary>
    /// Kiểm tra giá trị value có rỗng không?
    /// Nếu value là rỗng, trả về true; ngược lại trả về false.
    /// </summary>
    /// <param name="value">Giá trị cần kiểm tra.</param>
    /// <returns>Nếu value là rỗng, trả về true; ngược lại trả về false.</returns>
    public static bool IsEmpty(this object value)
    {
      //Nếu value là null
      if (value == null)
        //Trả về false
        return false;

      //Nếu value = ""
      if (value.ToString() == "")
        //Trả về true
        return true;
      //Ngược lại
      else
        //Trả về false
        return false;
    }

    /// <summary>
    /// Kiểm tra giá trị value có chứa toàn khoảng trắng không?
    /// Nếu value chứa toàn khoảng trắng, trả về true; ngược lại, trả về false.
    /// </summary>
    /// <param name="value">Giá trị cần kiểm tra.</param>
    /// <returns>Nếu value chứa toàn khoảng trắng, trả về true; ngược lại, trả về false.</returns>
    public static bool IsWhileSpace(this object value)
    {
      if (value == null)
        return false;

      //Khai báo lớp regex để so khớp theo mẫu
      Regex regex = new Regex(@"^\s+$");

      //Nếu value khớp với mẫu
      if (regex.IsMatch(value.ToString()))
        //Trả về true
        return true;
      //Ngược lại
      else
        //Trả về false
        return false;
    }

    /// <summary>
    /// Kiểm tra giá trị value là Null hoặc rỗng không?
    /// Nếu value là Null hoặc rỗng, trả về true; ngược lại, trả về false.
    /// </summary>
    /// <param name="value">Giá trị cần kiểm tra.</param>
    /// <returns>Nếu value là Null hoặc rỗng, trả về true; ngược lại, trả về false.</returns>
    public static bool IsNullOrEmpty(this object value)
    {
      //Nếu value là null, trả về true
      if (value == null)
        return true;

      //Nếu value là empty, trả về true
      if (value.ToString() == "")
        return true;

      //Ngược lại, trả về false
      return false;
    }

    /// <summary>
    /// Kiểm tra giá trị value là Null hoặc rỗng hoặc toàn khoảng trắng không?
    /// Nếu value là Null hoặc hoặc toàn khoảng trắng rỗng, trả về true; ngược lại, trả về false.
    /// </summary>
    /// <param name="value">Giá trị cần kiểm tra.</param>
    /// <returns>Nếu value là Null hoặc rỗng hoặc toàn khoảng trắng, trả về true; ngược lại, trả về false.</returns>
    public static bool IsNullOrEmptyOrWhileSpace(this object value)
    {
      //Nếu value là NULL hoặc rỗng
      if (IsNullOrEmpty(value))
      {
        return true;
      }

      //Nếu value là toàn khoảng trắng
      if (IsWhileSpace(value))
      {
        return true;
      }
      //Ngược lại
      return false;
    }

    /// <summary>
    /// Kiểm tra giá trị value chỉ chứa toàn số không?
    /// Nếu value chỉ chứa toàn số, trả về true; ngược lại, trả về false.
    /// </summary>
    /// <param name="value">Giá trị cần kiểm tra.</param>
    /// <returns>Nếu value chỉ chứa toàn số, trả về true; ngược lại, trả về false.</returns>
    public static bool IsOnlyNumber(this object value)
    {
      if (value == null)
        return false;

      //Khai báo lớp regex để so khớp theo mẫu
      Regex regex = new Regex(@"^[0-9]+$");

      //Nếu value khớp với mẫu
      if (regex.IsMatch(value.ToString()))
        //Trả về true
        return true;
      //Ngược lại
      else
        //Trả về false
        return false;
    }

    /// <summary>
    /// Kiểm tra giá trị value chỉ chứa toàn chữ không?
    /// Nếu value chỉ chứa toàn chữ, trả về true; ngược lại, trả về false.
    /// </summary>
    /// <param name="value">Giá trị cần kiểm tra.</param>
    /// <returns>Nếu value chỉ chứa toàn chữ, trả về true; ngược lại, trả về false.</returns>
    public static bool IsOnlyLetter(this object value)
    {
      if (value == null)
        return false;

      //Khai báo lớp regex để so khớp theo mẫu
      Regex regex = new Regex(@"^[a-zA-Z]+$");

      //Nếu value khớp với mẫu
      if (regex.IsMatch(value.ToString()))
        //Trả về true
        return true;
      //Ngược lại
      else
        //Trả về false
        return false;
    }

    /// <summary>
    /// Kiểm tra giá trị value chỉ chứa toàn chữ hoặc số không?
    /// Nếu value chỉ chứa toàn chữ hoặc số hoặc cả hai, trả về true; ngược lại, trả về false.
    /// </summary>
    /// <param name="value">Giá trị cần kiểm tra.</param>
    /// <returns>Nếu value chỉ chứa toàn chữ hoặc số hoặc cả hai, trả về true; ngược lại, trả về false.</returns>
    public static bool IsOnlyLetterOrNumeric(this object value)
    {
      if (value == null)
        return false;

      //Khai báo lớp regex để so khớp theo mẫu
      Regex regex = new Regex(@"^[a-zA-Z0-9]+$");

      //Nếu value khớp với mẫu
      if (regex.IsMatch(value.ToString()))
        //Trả về true
        return true;
      //Ngược lại
      else
        //Trả về false
        return false;
    }

    /// <summary>
    /// Kiểm tra giá trị value là định dạng email hợp lệ không?
    /// Nếu value là định dạng email hợp lệ, trả về true; ngược lại, trả về false.
    /// </summary>
    /// <param name="value">Giá trị cần kiểm tra.</param>
    /// <returns>Nếu value là định dạng email hợp lệ, trả về true; ngược lại, trả về false.</returns>
    public static bool IsEmailFormat(this object value)
    {
      if (value == null)
        return false;

      //Khai báo lớp regex để so khớp theo mẫu
      Regex regex = new Regex(@"^[0-9a-zA-Z](\w+\.)*[0-9a-zA-Z]+@\w+([-.]\w+)*(\w*[.])[a-zA-Z]{2,6}$");
      //Regex regex = new Regex(@"^[a-zA-Z0-9][a-zA-Z0-9\._]+[a-zA-Z0-9]@[a-zA-Z0-9-]+(\.[a-zA-Z]+)+$");

      //Nếu value khớp với mẫu
      if (regex.IsMatch(value.ToString()))
        //Trả về true
        return true;
      //Ngược lại
      else
        //Trả về false
        return false;
    }

    /// <summary>
    /// Kiểm tra giá trị value là định dạng IP hợp lệ không?
    /// Nếu value là định dạng IP hợp lệ, trả về true; ngược lại, trả về false.
    /// </summary>
    /// <param name="value">Giá trị cần kiểm tra.</param>
    /// <returns>Nếu value là định dạng IP hợp lệ, trả về true; ngược lại, trả về false.</returns>
    public static bool IsIPFormat(this object value)
    {
      if (value == null)
        return false;

      //Khai báo lớp regex để so khớp theo mẫu
      //Regex regex = new Regex(@"^[1-9][0-9]{0,2}\.[0-9]+\.[0-9]+");
      Regex regex = new Regex(@"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$");


      //Nếu value khớp với mẫu
      if (regex.IsMatch(value.ToString()))
        //Trả về true
        return true;
      //Ngược lại
      else
        //Trả về false
        return false;
    }

    /// <summary>
    /// Kiểm tra giá trị value là định dạng ngày tháng năm hợp lệ không?
    /// Nếu value là định dạng ngày tháng năm hợp lệ, trả về true; ngược lại, trả về false.
    /// </summary>
    /// <param name="value">Giá trị cần kiểm tra.</param>
    /// <returns>Nếu value là định dạng ngày tháng năm hợp lệ, trả về true; ngược lại, trả về false.</returns>
    public static bool IsDateFormat(this object value)
    {

      if (value == null)
        return false;

      //Khai báo lớp regex để so khớp theo mẫu
      Regex regex = new Regex(@"^((((0?[1-9]|[12]\d|30)(?<s>[-\/])(0?[13-9]|1[012])\k<s>(\d{3}[1-9]))|(31(?<s>[-\/])([13578]|1[02])\k<s>(\d{3}[1-9])))|((29)(?<s>[-\/])0?2\k<s>(\d\d[2468][048]|\d\d[13579][26]|[13579][26]00|[02468][048]00))|(([0-2]?[0-8])(?<s>[-\/])0?2\k<s>(\d{4})))$");

      //Nếu value khớp với mẫu
      if (regex.IsMatch(value.ToString()))
        //Trả về true
        return true;
      //Ngược lại
      else
        //Trả về false
        return false;
    }

    /// <summary>
    /// Kiểm tra giá trị value là định dạng giờ phút giây hợp lệ không?
    /// Nếu value là định dạng giờ phút giây hợp lệ, trả về true; ngược lại, trả về false.
    /// </summary>
    /// <param name="value">Giá trị cần kiểm tra.</param>
    /// <returns>Nếu value là định dạng giờ phút giây hợp lệ, trả về true; ngược lại, trả về false.</returns>
    public static bool IsTimeFormat(this object value)
    {

      {

        if (value == null)
          return false;

        //Khai báo lớp regex để so khớp theo mẫu
        Regex regex = new Regex(@"^(((0?[1-9]|1[012]):[0-5]?\d(:[0-5]?\d)?\s*([aApP][mM])?)|((1[3-9]|2[0-3]):[0-5]?\d(:[0-5]\d)?\s*([pP][mM])?)|(0:[0-5]?\d(:[0-5]?\d)?\s*([Aa][mM])?))$");

        //Nếu value khớp với mẫu
        if (regex.IsMatch(value.ToString()))
          //Trả về true
          return true;
        //Ngược lại
        else
          //Trả về false
          return false;
      }

    }
  }

  public static class CookieeUtility
  {
    public static User UserCookie
    {
      get
      {
        var itemCookie = HttpContext.Current.Request.Cookies["UserCookie"];
        if (itemCookie != null)
        {
          User userCookie = new JavaScriptSerializer().Deserialize<User>(itemCookie.Value);
          return userCookie;
        }
        else
          return null;
      }
      set
      {
        string userJson = new JavaScriptSerializer().Serialize(value);
        HttpCookie userCookie = new HttpCookie("UserCookie", userJson)
        {
          Expires = DateTime.Now.AddDays(30)
        };
        HttpContext.Current.Response.Cookies.Add(userCookie);
      }
    }

    public static void ExpireAllCookies()
    {
      if (HttpContext.Current != null)
      {
        int cookieCount = HttpContext.Current.Request.Cookies.Count;
        for (var i = 0; i < cookieCount; i++)
        {
          var cookie = HttpContext.Current.Request.Cookies[i];
          if (cookie != null)
          {
            var expiredCookie = new HttpCookie(cookie.Name)
            {
              Expires = DateTime.Now.AddDays(-1),
              Domain = cookie.Domain
            };
            HttpContext.Current.Response.Cookies.Add(expiredCookie);
          }
        }

        // clear cookies server side
        HttpContext.Current.Request.Cookies.Clear();
      }
    }
  }

  public static class DialogUtility
  {
    #region FolderDialog
    /// <summary>
    /// Hiển thị một hộp thoại cho phép chọn thư mục
    /// </summary>
    /// <returns>
    /// Trả về đường dẫn đến thư mục đã chọn
    /// </returns>
    /// <remarks>
    /// Nếu không chọn thư mục, thì trả về chuỗi rỗng
    /// </remarks>
    public static string FolderDialog()
    {
      //1. Tạo hộp thoại Chọn Thư Mục
      FolderBrowserDialog dialog = new FolderBrowserDialog();

      //2. Hiện hộp thoại Chọn Thư Mục
      DialogResult result = dialog.ShowDialog();

      //3. Nếu người dùng có Chọn Thư Mục, thì trả về URL đã chọn
      if (result == DialogResult.OK)
        return dialog.SelectedPath;

      //4. Ngược lại, trả về rỗng
      return string.Empty;
    }

    /// <summary>
    /// Hiển thị một hộp thoại cho phép chọn thư mục
    /// </summary>
    /// <param name="showNewFolderButton">
    /// Thiết lập Ẩn/Hiện nút thêm thư mục mới. True: hiện; False: ẩn
    /// </param>
    /// <returns>
    /// Trả về đường dẫn đến thư mục đã chọn
    /// </returns>
    /// <remarks>
    /// Nếu không chọn thư mục, thì trả về chuỗi rỗng
    /// </remarks>
    public static string FolderDialog(bool showNewFolderButton)
    {
      //1. Tạo hộp thoại Chọn Thư Mục
      FolderBrowserDialog dialog = new FolderBrowserDialog();

      //2. Thiết lập Ẩn/Hiện nút thêm thư mục mới
      dialog.ShowNewFolderButton = showNewFolderButton;

      //3. Hiện hộp thoại Chọn Thư Mục
      DialogResult result = dialog.ShowDialog();

      //4. Nếu người dùng có Chọn Thư Mục, thì trả về URL đã chọn
      if (result == DialogResult.OK)
        return dialog.SelectedPath;

      //5. Ngược lại, trả về rỗng
      return string.Empty;
    }

    /// <summary>
    /// Hiển thị một hộp thoại cho phép chọn thư mục
    /// </summary>
    /// <param name="title">
    /// Tiêu đề của hộp thoại
    /// </param>
    /// <param name="showNewFolderButton">
    /// Thiết lập Ẩn/Hiện nút thêm thư mục mới. True: hiện; False: ẩn
    /// </param>
    /// <returns>
    /// Trả về đường dẫn đến thư mục đã chọn
    /// </returns>
    /// <remarks>
    /// Nếu không chọn thư mục, thì trả về chuỗi rỗng
    /// </remarks>
    public static string FolderDialog(string title, bool showNewFolderButton)
    {
      //1. Tạo hộp thoại Chọn Thư Mục
      FolderBrowserDialog dialog = new FolderBrowserDialog();

      //2. Thiết lập tiêu đề hộp thoại
      dialog.Description = title;

      //2. Thiết lập Ẩn/Hiện nút thêm thư mục mới
      dialog.ShowNewFolderButton = showNewFolderButton;

      //3. Hiện hộp thoại Chọn Thư Mục
      DialogResult result = dialog.ShowDialog();

      //4. Nếu người dùng có Chọn Thư Mục, thì trả về URL đã chọn
      if (result == DialogResult.OK)
        return dialog.SelectedPath;

      //5. Ngược lại, trả về rỗng
      return string.Empty;
    }
    #endregion

    #region FileDialog
    /// <summary>
    /// Hiển thị một hộp thoại cho phép chọn file
    /// </summary>
    /// <returns>
    /// Trả về đường dẫn đến file đã chọn
    /// </returns>
    /// <remarks>
    /// Nếu không chọn file, thì trả về chuỗi rỗng
    /// </remarks>
    public static string FileDialog()
    {
      //1. Tạo hộp thoại Chọn File
      OpenFileDialog dialog = new OpenFileDialog();

      //2. Hiện hộp thoại Chọn File
      DialogResult result = dialog.ShowDialog();

      //3. Nếu người dùng có Chọn Thư Mục, thì trả về URL đã chọn
      if (result == DialogResult.OK)
        return dialog.FileName;

      //4. Ngược lại, trả về rỗng
      return string.Empty;
    }

    /// <summary>
    /// Hiển thị một hộp thoại cho phép chọn file
    /// </summary>
    /// <param name="title">
    /// Tiêu đề của hộp thoại
    /// </param>
    /// <returns>
    /// Trả về đường dẫn đến file đã chọn
    /// </returns>
    /// <remarks>
    /// Nếu không chọn file, thì trả về chuỗi rỗng
    /// </remarks>
    public static string FileDialog(string title)
    {
      //1. Tạo hộp thoại Chọn File
      OpenFileDialog dialog = new OpenFileDialog();

      //2. Thiết lập tiêu đề hộp thoại
      dialog.Title = title;

      //3. Hiện hộp thoại Chọn File
      DialogResult result = dialog.ShowDialog();

      //4. Nếu người dùng có Chọn Thư Mục, thì trả về URL đã chọn
      if (result == DialogResult.OK)
        return dialog.FileName;

      //5. Ngược lại, trả về rỗng
      return string.Empty;
    }

    /// <summary>
    /// Hiển thị một hộp thoại cho phép chọn file
    /// </summary>
    /// <param name="title">
    /// Tiêu đề của hộp thoại
    /// </param>
    /// <param name="filter">
    /// Thiết lập bộ lọc loại file
    /// VD: "Text file|*.txt|Image file|*.jpg;*.jpeg;*.gif;*.png|All file|*.*"
    /// </param>
    /// <returns>
    /// Trả về đường dẫn đến file đã chọn
    /// </returns>
    /// <remarks>
    /// Nếu không chọn file, thì trả về chuỗi rỗng
    /// </remarks>
    public static string FileDialog(string title, string filter)
    {
      //1. Tạo hộp thoại Chọn File
      OpenFileDialog dialog = new OpenFileDialog();

      //2. Thiết lập tiêu đề hộp thoại
      dialog.Title = title;

      //3. Thiết lập bộ lọc loại file
      dialog.Filter = filter;

      //4. Hiện hộp thoại Chọn File
      DialogResult result = dialog.ShowDialog();

      //5. Nếu người dùng có Chọn Thư Mục, thì trả về URL đã chọn
      if (result == DialogResult.OK)
        return dialog.FileName;

      //6. Ngược lại, trả về rỗng
      return string.Empty;
    }
    #endregion

    #region FileSaveDialog
    /// <summary>
    /// Hiển thị một hộp thoại cho phép lưu file
    /// </summary>
    /// <returns>
    /// Trả về đường dẫn đến file đã chọn, hoặc tên file mới nhập
    /// </returns>
    /// <remarks>
    /// Nếu không chọn file, thì trả về chuỗi rỗng
    /// </remarks>
    public static string FileSaveDialog()
    {
      //1. Tạo hộp thoại Chọn SaveFile
      SaveFileDialog dialog = new SaveFileDialog();

      //2. Hiện hộp thoại Chọn File
      DialogResult result = dialog.ShowDialog();

      //3. Nếu người dùng có Chọn Thư Mục, thì trả về URL đã chọn
      if (result == DialogResult.OK)
        return dialog.FileName;

      //4. Ngược lại, trả về rỗng
      return string.Empty;
    }

    /// <summary>
    /// Hiển thị một hộp thoại cho phép lưu file
    /// </summary>
    /// <param name="title">
    /// Tiêu đề của hộp thoại
    /// </param>
    /// <returns>
    /// Trả về đường dẫn đến file đã chọn, hoặc tên file mới nhập
    /// </returns>
    /// <remarks>
    /// Nếu không chọn file, thì trả về chuỗi rỗng
    /// </remarks>
    public static string FileSaveDialog(string title)
    {
      //1. Tạo hộp thoại Chọn SaveFile
      SaveFileDialog dialog = new SaveFileDialog();

      //2. Thiết lập tiêu đề hộp thoại save file
      dialog.Title = title;

      //3. Hiện hộp thoại Chọn File
      DialogResult result = dialog.ShowDialog();

      //4. Nếu người dùng có Chọn Thư Mục, thì trả về URL đã chọn
      if (result == DialogResult.OK)
        return dialog.FileName;

      //5. Ngược lại, trả về rỗng
      return string.Empty;
    }

    /// <summary>
    /// Hiển thị một hộp thoại cho phép lưu file
    /// </summary>
    /// <param name="title">
    /// Tiêu đề của hộp thoại
    /// </param>
    /// Thiết lập bộ lọc loại file sẽ lưu
    /// VD: "Text file|*.txt|Image file|*.jpg;*.jpeg;*.gif;*.png|All file|*.*"
    /// <returns>
    /// Trả về đường dẫn đến file đã chọn, hoặc tên file mới nhập
    /// </returns>
    /// <remarks>
    /// Nếu không chọn file, thì trả về chuỗi rỗng
    /// </remarks>
    public static string FileSaveDialog(string title, string filter)
    {
      //1. Tạo hộp thoại Chọn SaveFile
      SaveFileDialog dialog = new SaveFileDialog();

      //2. Thiết lập tiêu đề hộp thoại save file
      dialog.Title = title;

      //3. Thiết lập bộ lọc loại file để save
      dialog.Filter = filter;

      //4. Hiện hộp thoại Chọn File
      DialogResult result = dialog.ShowDialog();

      //5. Nếu người dùng có Chọn Thư Mục, thì trả về URL đã chọn
      if (result == DialogResult.OK)
        return dialog.FileName;

      //6. Ngược lại, trả về rỗng
      return string.Empty;
    }
    #endregion

    #region MessageBox
    /// <summary>
    /// Hiển thị một hộp thoại xác nhận, có 2 nút: Yes và No
    /// </summary>
    /// <param name="title">
    /// Tiêu đề của hộp thoại
    /// </param>
    /// <param name="message">
    /// Nội dung thông báo
    /// </param>
    /// <returns>
    /// Nếu chọn Yes, thì trả về True; Ngược lại, thì trả về False
    /// </returns>
    public static bool Confirm(string title, string message)
    {
      DialogResult result;
      result = MessageBox.Show(message, title, MessageBoxButtons.YesNo);

      if (result == DialogResult.Yes)
        return true;
      else
        return false;
    }

    /// <summary>
    /// Hiển thị một hộp thoại yêu cầu người sử dụng nhập một chuỗi theo yêu cầu.
    /// Trả về giá trị người sử dụng đã nhập. Nếu người dùng không nhập, trả về giá trị rỗng.
    /// </summary>
    /// <param name="title">
    /// Tiêu đề của hộp thoại
    /// </param>
    /// <param name="message">
    /// Nội dung thông báo
    /// </param>
    /// <param name="buttonText">Tiêu đề của nút xác nhận trong hộp thoại.</param>
    /// <param name="width">Chiều dài của hộp thoại. Đơn vị tính là px.</param>
    /// <param name="formPadding">Khoảng cách lề 4 cạnh của Form.</param>
    /// <returns>Trả về giá trị người sử dụng đã nhập. Nếu người dùng không nhập, trả về giá trị rỗng.</returns>
    public static string Promt(string title, string message, string buttonText, int width, int formPadding)
    {
      //Tạo khoảng cách giữa các đối tượng trên Form
      int controlMargin = 3;

      //Tạo một form mới
      Form miniForm = new Form();

      //Thiết lập chiều dài cho Form
      miniForm.Width = width;

      //Thiết lập thanh tiêu đề
      miniForm.Text = title;
      miniForm.MaximizeBox = false;
      miniForm.MinimizeBox = false;

      //Thiết lập vị trí hiển thị
      miniForm.StartPosition = FormStartPosition.CenterScreen;

      //Không cho Resize form
      miniForm.FormBorderStyle = FormBorderStyle.FixedDialog;

      //Tạo một Label để hiện thông điệp
      Label Label_Message = new Label();
      Label_Message.Left = formPadding;
      Label_Message.Top = formPadding;
      Label_Message.Width = width;
      Label_Message.Height = 15;
      Label_Message.Text = message;

      //Tạo một Textbox cho phép nhập nội dung vào bên trong
      TextBox TextBox_Text = new TextBox();
      TextBox_Text.Left = formPadding;
      TextBox_Text.Top = Label_Message.Top + Label_Message.Height + controlMargin;
      TextBox_Text.Width = miniForm.ClientSize.Width - formPadding * 2;
      TextBox_Text.Anchor = AnchorStyles.Left | AnchorStyles.Right;

      //Tạo một Button
      Button Button_OK = new Button();
      Button_OK.Width = 100;
      Button_OK.Text = buttonText;
      Button_OK.Top = TextBox_Text.Top + TextBox_Text.Height + controlMargin;
      Button_OK.Left = TextBox_Text.Left + TextBox_Text.Width + 1 - Button_OK.Width;
      Button_OK.Click += (sender, e) => { miniForm.Close(); };

      //Thiết lập lại chiều cao cho Form
      miniForm.Height = Button_OK.Top + Button_OK.Height + formPadding + 40;

      //Đưa các Control vào trang
      miniForm.Controls.Add(TextBox_Text);
      miniForm.Controls.Add(Button_OK);
      miniForm.Controls.Add(Label_Message);

      //Thiết lập nút mặc định khi nhấn Enter
      miniForm.AcceptButton = Button_OK;

      //Hiển thị hộp thoại lên
      miniForm.ShowDialog();

      //Khi nhấn OK thì trả về kết quả là giá trị đã nhập trong ô TextBox;
      return TextBox_Text.Text;
    }
    #endregion
  }

  public static class FolderUtility
  {
    /// <summary>
    /// Kiểm tra sự tồn tại của một folder tại url.
    /// Nếu folder có tồn tại: trả về true; ngược lại trả về false.
    /// Nếu url là null, empty hoặc không hợp lệ, kết quả trả về là false.
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần kiểm tra tồn tại.</param>
    /// <returns>Nếu folder có tồn tại: trả về true; ngược lại trả về false.</returns>
    public static bool IsExists(string url)
    {
      return Directory.Exists(url);
    }

    /// <summary>
    /// Tạo folder tại url.
    /// Nếu url có dạng đa cấp như: C:\User\Image\Demo. Thì các folder chưa có sẵn sẽ được tạo một cách lần lượt từ cấp lớn đến nhỏ. VD: User -> Image -> Demo
    /// Nếu folder được tạo ra thành công hoặc đã có sẵn thì trả về true; ngược lại trả về false.
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần tạo mới.</param>
    /// <param name="error">Chứa lỗi ngoại lệ (nếu có) trong quá trình tạo folder.</param>
    /// <returns>Nếu folder được tạo ra thành công hoặc đã có sẵn thì trả về true; ngược lại trả về false.</returns>
    public static bool CreateFolder(string url, ref Exception error)
    {
      //1. Kiểm tra nếu folder tại url đã tồn tại thì không cần tạo, trả về true
      if (IsExists(url))
      {
        return true;
      }

      try
      {
        //2. Tạo folder tại url
        Directory.CreateDirectory(url);
      }
      catch (Exception ex)
      {
        error = ex;
        return false;
      }

      //3. Trả về kết quả thành công
      return true;
    }

    /// <summary>
    /// Tính tổng dung lượng của một folder tại url. Đơn vị tính là kilobyte.
    /// Nếu url không tồn tại, trả về 0.
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần tính dung lượng.</param>
    /// <param name="searchOption">Có 2 tùy chọn: TopDirectoryOnly: chỉ xét trong folder hiện tại; AllDirectories: Bao gồm folder hiện tại và mọi folder con bên trong.</param>
    /// <returns>Trả về tổng dung lượng của một folder. Đơn vị tính là kilobyte.</returns>
    public static long GetSize(string url, SearchOption searchOption)
    {
      //1. Kiểm tra nếu folder tại url không tồn tại thì trả về 0
      if (!IsExists(url))
        return 0;

      //2. Liệt kê danh sách file nằm trong folder
      string[] fileUrls = Directory.GetFiles(url, "*.*", searchOption);

      //3. Tạo một biến để chứa dung lượng
      long size = 0;

      //4. Lặp qua từng file, cộng dồn dung lượng các file lại với nhau
      foreach (string fileUrl in fileUrls)
      {
        //Load file từ url
        FileInfo file = new FileInfo(fileUrl);
        //Cộng dồn dung lượng lại với nhau
        size += file.Length;
      }

      //5. Trả về kết quả
      return size;
    }

    /// <summary>
    /// Đếm số lượng file bên trong folder tại url.
    /// Nếu folder tại url không tồn tại, trả về 0.
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần đếm số lượng file.</param>
    /// <param name="searchOption">Có 2 tùy chọn: TopDirectoryOnly: chỉ xét trong folder hiện tại; AllDirectories: Bao gồm folder hiện tại và mọi folder con bên trong.</param>
    /// <returns>Trả về số lượng file bên trong folder tại url.</returns>
    public static int CountFiles(string url, SearchOption searchOption)
    {
      //1. Kiểm tra nếu folder tại url không tồn tại thì trả về 0
      if (!IsExists(url))
        return 0;

      //2. Liệt kê danh sách file nằm trong folder
      string[] fileUrls = Directory.GetFiles(url, "*.*", searchOption);

      //3. Trả về số lượng file
      return fileUrls.Length;
    }

    /// <summary>
    /// Đếm số lượng folder con bên trong folder tại url.
    /// Nếu folder tại url không tồn tại, trả về 0.
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần đếm số lượng folder con.</param>
    /// <param name="searchOption">Có 2 tùy chọn: TopDirectoryOnly: chỉ xét trong folder hiện tại; AllDirectories: Bao gồm folder hiện tại và mọi folder con bên trong.</param>
    /// <returns>Trả về số lượng folder con bên trong folder tại url.</returns>
    public static int CountFolders(string url, SearchOption searchOption)
    {
      //1. Kiểm tra nếu folder tại url không tồn tại thì trả về 0
      if (!IsExists(url))
        return 0;

      //2. Liệt kê danh sách folder nằm trong folder đang xét
      string[] fileUrls = Directory.GetDirectories(url, "*.*", searchOption);

      //3. Trả về số lượng folder đếm được
      return fileUrls.Length;
    }

    /// <summary>
    /// Đếm số lượng file và folder con bên trong folder tại url.
    /// Nếu folder tại url không tồn tại, trả về 0.
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần đếm số lượng file + folder.</param>
    /// <param name="searchOption">Có 2 tùy chọn: TopDirectoryOnly: chỉ xét trong folder hiện tại; AllDirectories: Bao gồm folder hiện tại và mọi folder con bên trong.</param>
    /// <returns>Trả về số lượng file + folder con bên trong folder tại url.</returns>
    public static int CountItems(string url, SearchOption searchOption)
    {
      //1. Kiểm tra nếu folder tại url không tồn tại thì trả về 0
      if (!IsExists(url))
        return 0;

      //2. Đếm số lượng file
      int fileNumbers = CountFiles(url, searchOption);

      //3. Đếm số lượng folder
      int folderNumbers = CountFolders(url, searchOption);

      //4. Cộng tổng số lượng file và folder
      int itemNumbers = fileNumbers + folderNumbers;

      //5. Trả về kết quả
      return itemNumbers;
    }

    /// <summary>
    /// Di chuyển một folder từ url đến newUrl. Có bắt lỗi ngoại lệ (nếu có).
    /// Nếu di chuyển thành công: trả về true; ngược lại trả về false.
    /// Nếu có lỗi ngoại lệ xảy ra thì trả về false.
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần chuyển đi. Ví dụ: C:\Images</param>
    /// <param name="newUrl">Đường dẫn đến folder cần chuyển đến. Ví dụ: C:\Document\Images</param>
    /// <param name="error">Chứa lỗi ngoại lệ (nếu có) trong quá trình di chuyển folder.</param>
    /// <returns>Nếu di chuyển thành công: trả về true; ngược lại trả về false.</returns>
    public static bool Move(string url, string newUrl, ref Exception error)
    {
      //1. Kiểm tra nếu folder tại url không tồn tại thì trả về false
      if (!IsExists(url))
      {
        string message = string.Format("The folder with path is not exist: {0}", url);
        error = new Exception(message);
        return false;
      }

      //2. Load folder từ url
      DirectoryInfo folder = new DirectoryInfo(url);

      try
      {
        //3. Di chuyển folder sang newUrl
        folder.MoveTo(newUrl);
      }
      catch (Exception ex)
      {
        error = ex;
        return false;
      }

      //4. Trả về kết quả thành công
      return true;
    }

    /// <summary>
    /// Đổi tên một folder sang tên mới. Có bắt lỗi ngoại lệ (nếu có).
    /// Nếu đổi tên thành công: trả về true; ngược lại trả về false.
    /// Nếu có lỗi ngoại lệ xảy ra thì trả về false.
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần đổi tên.</param>
    /// <param name="newName">Tên mới của folder.</param>
    /// <param name="error">Chứa lỗi ngoại lệ (nếu có) trong quá trình đổi tên folder.</param>
    /// <returns>Nếu đổi tên thành công: trả về true; ngược lại trả về false.</returns>
    public static bool Rename(string url, string newName, ref Exception error)
    {
      //1. Kiểm tra nếu folder tại url không tồn tại thì trả về false
      if (!IsExists(url))
      {
        string message = string.Format("The folder with path is not exist: {0}", url);
        error = new Exception(message);
        return false;
      }

      //2. Load folder từ url
      DirectoryInfo folder = new DirectoryInfo(url);

      //3. Load folder cha của url
      DirectoryInfo parentFolder = folder.Parent;

      //4. Tạo url với tên mới
      string newUrl = Path.Combine(parentFolder.FullName, newName);

      //5. Di chuyển folder từ url sang newUrl
      return Move(url, newUrl, ref error);
    }

    /// <summary>
    /// Xóa một folder. Có bắt lỗi ngoại lệ (nếu có).
    /// Nếu xóa thành công hoặc folder không tồn tại: trả về true; ngược lại trả về false.
    /// Nếu có lỗi ngoại lệ xảy ra thì trả về false.
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần xóa.</param>
    /// <param name="error">Chứa lỗi ngoại lệ (nếu có) trong quá trình xóa folder.</param>
    /// <returns>Nếu xóa thành công hoặc folder không tồn tại: trả về true; ngược lại trả về false.</returns>
    public static bool Delete(string url, ref Exception error)
    {
      //1. Kiểm tra nếu folder tại url không tồn tại thì trả về true
      if (!IsExists(url))
      {
        return true;
      }

      //2. Load folder từ url
      DirectoryInfo folder = new DirectoryInfo(url);

      try
      {
        //3. Xóa folder
        folder.Delete(true);
      }
      catch (Exception ex)
      {
        error = ex;
        return false;
      }

      //4. Trả về kết quả thành công
      return true;
    }

    /// <summary>
    /// Xóa hết file và folder con bên trong folder tại url. Có bắt lỗi ngoại lệ (nếu có).
    /// Nếu xóa hết thành công: trả về true; ngược lại trả về false.
    /// Nếu có lỗi ngoại lệ xảy ra thì trả về false.
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần xóa hết file và folder con bên trong.</param>
    /// <param name="error">Chứa lỗi ngoại lệ (nếu có) trong quá trình xóa hết.</param>
    /// <returns>Nếu xóa thành công: trả về true; ngược lại trả về false.</returns>
    public static bool Empty(string url, ref Exception error)
    {
      //1. Kiểm tra nếu folder tại url không tồn tại thì trả về false
      if (!IsExists(url))
      {
        string message = string.Format("The folder with path is not exist: {0}", url);
        error = new Exception(message);
        return false;
      }

      //2. Load folder từ url
      DirectoryInfo folder = new DirectoryInfo(url);

      try
      {
        //3. Xóa tất cả file bên trong folder này
        foreach (FileInfo file in folder.GetFiles())
        {
          file.Delete();
        }

        //4. Xóa tất cả folder bên trong folder này
        foreach (DirectoryInfo subFolder in folder.GetDirectories())
        {
          subFolder.Delete(true);
        }
      }
      catch (Exception ex)
      {
        error = ex;
        return false;
      }

      //5. Trả về kết quả thành công
      return true;
    }

    /// <summary>
    /// Tìm kiếm danh sách folder con bên trong folder tại url.
    /// Trả về danh sách folder con tìm được bên trong folder tại url
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần tìm kiếm folder con bên trong.</param>
    /// <param name="searchPattern">
    /// Mẫu để tìm kiếm.
    /// VD1:  image* : tìm tất cả các folder con có tên bắt đầu là image.
    /// VD2: *image  : tìm tất cả các folder con có tên kết thúc là image
    /// VD3: *image* : tìm tất cả các folder con có tên chứa chữ image
    /// VD4: *       : tìm tất cả các folder con
    /// </param>
    /// <param name="searchOption">Có 2 tùy chọn: TopDirectoryOnly: chỉ xét trong folder hiện tại; AllDirectories: Bao gồm folder hiện tại và mọi folder con bên trong.</param>
    /// <returns>Trả về danh sách folder con tìm được bên trong folder tại url</returns>
    public static DirectoryInfo[] SearchFolders(string url, string searchPattern, SearchOption searchOption)
    {
      //1. Kiểm tra nếu folder tại url không tồn tại thì trả về false
      if (!IsExists(url))
      {
        return null;
      }

      //2. Load folder từ url
      DirectoryInfo folder = new DirectoryInfo(url);

      //3. Trả về danh sách thông tin các folder
      return folder.GetDirectories(searchPattern, searchOption);
    }

    /// <summary>
    /// Tìm kiếm danh sách file bên trong folder tại url.
    /// Trả về danh sách file tìm được bên trong folder tại url
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần tìm kiếm file bên trong.</param>
    /// <param name="searchPattern">
    /// Mẫu để tìm kiếm.
    /// VD1:  image* : tìm tất cả các file có tên bắt đầu là image.
    /// VD2: *image  : tìm tất cả các file có tên kết thúc là image
    /// VD3: *image* : tìm tất cả các file có tên chứa chữ image
    /// VD4: *.jpg   : tìm tất cả các file có phần mở rộng là .jpg
    /// VD5: image.* : tìm tất cả các file có tên là image với phần mở rộng là bất kỳ
    /// VD6: *       : tìm tất cả các file
    /// </param>
    /// <param name="searchOption">Có 2 tùy chọn: TopDirectoryOnly: chỉ xét trong folder hiện tại; AllDirectories: Bao gồm folder hiện tại và mọi folder con bên trong.</param>
    /// <returns>Trả về danh sách file tìm được bên trong folder tại url</returns>
    public static FileInfo[] SearchFiles(string url, string searchPattern, SearchOption searchOption)
    {
      //1. Kiểm tra nếu folder tại url không tồn tại thì trả về false
      if (!IsExists(url))
      {
        return null;
      }

      //2. Load folder từ url
      DirectoryInfo folder = new DirectoryInfo(url);

      //3. Trả về danh sách thông tin các file
      return folder.GetFiles(searchPattern, searchOption);
    }

    /// <summary>
    /// Tìm kiếm danh sách tên folder con bên trong folder tại url.
    /// Trả về danh sách tên folder con tìm được bên trong folder tại url
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần tìm kiếm folder con bên trong.</param>
    /// <param name="searchPattern">
    /// Mẫu để tìm kiếm.
    /// VD1:  image* : tìm tất cả các folder con có tên bắt đầu là image.
    /// VD2: *image  : tìm tất cả các folder con có tên kết thúc là image
    /// VD3: *image* : tìm tất cả các folder con có tên chứa chữ image
    /// VD4: *       : tìm tất cả các folder con
    /// </param>
    /// <param name="searchOption">Có 2 tùy chọn: TopDirectoryOnly: chỉ xét trong folder hiện tại; AllDirectories: Bao gồm folder hiện tại và mọi folder con bên trong.</param>
    /// <returns>Trả về danh sách tên folder con tìm được bên trong folder tại url</returns>
    public static string[] SearchFolderUrls(string url, string searchPattern, SearchOption searchOption)
    {
      //1. Load danh sách các folder info có trong folder tại url
      DirectoryInfo[] folderInfo = SearchFolders(url, searchPattern, searchOption);

      //2. Nếu không có folder con nào trong folder thì trả về null
      if (folderInfo == null)
        return null;

      //3. Trích lọc folder url từ các folder info
      var folderUrlList = from item in folderInfo
                          select item.FullName;

      //4. Trả kết quả về dạng mảng
      return folderUrlList.ToArray();
    }

    /// <summary>
    /// Tìm kiếm danh sách tên file bên trong folder tại url.
    /// Trả về danh sách tên file tìm được bên trong folder tại url
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần tìm kiếm file bên trong.</param>
    /// <param name="searchPattern">
    /// Mẫu để tìm kiếm.
    /// VD1:  image* : tìm tất cả các file có tên bắt đầu là image.
    /// VD2: *image  : tìm tất cả các file có tên kết thúc là image
    /// VD3: *image* : tìm tất cả các file có tên chứa chữ image
    /// VD4: *.jpg   : tìm tất cả các file có phần mở rộng là .jpg
    /// VD5: image.* : tìm tất cả các file có tên là image với phần mở rộng là bất kỳ
    /// VD6: *       : tìm tất cả các file
    /// </param>
    /// <param name="searchOption">Có 2 tùy chọn: TopDirectoryOnly: chỉ xét trong folder hiện tại; AllDirectories: Bao gồm folder hiện tại và mọi folder con bên trong.</param>
    /// <returns>Trả về danh sách tên file tìm được bên trong folder tại url</returns>
    public static string[] SearchFileUrls(string url, string searchPattern, SearchOption searchOption)
    {
      //1. Load danh sách các file info có trong folder tại url
      FileInfo[] fileInfo = SearchFiles(url, searchPattern, searchOption);

      //2. Nếu không có file nào trong folder thì trả về null
      if (fileInfo == null)
        return null;

      //3. Trích lọc file url từ các file info
      var fileUrlList = from item in fileInfo
                        select item.FullName;

      //4. Trả kết quả về dạng mảng
      return fileUrlList.ToArray();
    }

    /// <summary>
    /// Liệt kê danh sách folder con bên trong folder tại url.
    /// Trả về danh sách folder con bên trong folder tại url
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần liệt kê folder con bên trong.</param>
    /// <param name="searchOption">Có 2 tùy chọn: TopDirectoryOnly: chỉ xét trong folder hiện tại; AllDirectories: Bao gồm folder hiện tại và mọi folder con bên trong.</param>
    /// <returns>Trả về danh sách folder con bên trong folder tại url</returns>
    public static DirectoryInfo[] ListFolderInfos(string url, SearchOption searchOption)
    {
      return SearchFolders(url, "*", searchOption);
    }

    /// <summary>
    /// Liệt kê danh sách file bên trong folder tại url.
    /// Trả về danh sách file bên trong folder tại url
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần liệt kê file bên trong.</param>
    /// <param name="searchOption">Có 2 tùy chọn: TopDirectoryOnly: chỉ xét trong folder hiện tại; AllDirectories: Bao gồm folder hiện tại và mọi file bên trong.</param>
    /// <returns>Trả về danh sách file bên trong folder tại url</returns>
    public static FileInfo[] ListFileInfos(string url, SearchOption searchOption)
    {
      return SearchFiles(url, "*", searchOption);
    }

    /// <summary>
    /// Liệt kê danh sách tên folder con bên trong folder tại url.
    /// Trả về danh sách tên folder con tìm được bên trong folder tại url
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần tìm kiếm folder con bên trong.</param>
    /// <param name="searchOption">Có 2 tùy chọn: TopDirectoryOnly: chỉ xét trong folder hiện tại; AllDirectories: Bao gồm folder hiện tại và mọi folder con bên trong.</param>
    /// <returns>Trả về danh sách tên folder con bên trong folder tại url</returns>
    public static string[] ListFolderUrls(string url, SearchOption searchOption)
    {
      return SearchFolderUrls(url, "*", searchOption);
    }

    /// <summary>
    /// Liệt kê danh sách tên file bên trong folder tại url.
    /// Trả về danh sách tên file tìm được bên trong folder tại url
    /// </summary>
    /// <param name="url">Đường dẫn đến folder cần tìm kiếm file bên trong.</param>
    /// <param name="searchOption">Có 2 tùy chọn: TopDirectoryOnly: chỉ xét trong folder hiện tại; AllDirectories: Bao gồm folder hiện tại và mọi file bên trong.</param>
    /// <returns>Trả về danh sách tên file bên trong folder tại url</returns>
    public static string[] ListFileUrls(string url, SearchOption searchOption)
    {
      return SearchFileUrls(url, "*", searchOption);
    }

    /// <summary>
    /// Liệt kê danh sách tên các ổ đĩa trong máy tính.
    /// Trả về danh sách tên các ổ đĩa trong máy tính.
    /// </summary>
    /// <returns>Trả về danh sách tên các ổ đĩa trong máy tính.</returns>
    public static DriveInfo[] GetAllDrivers()
    {
      return DriveInfo.GetDrives();
    }

    /// <summary>
    /// Liệt kê danh sách tên các ổ đĩa trong máy tính.
    /// Trả về danh sách tên các ổ đĩa trong máy tính.
    /// </summary>
    /// <returns>Trả về danh sách tên các ổ đĩa trong máy tính.</returns>
    public static string[] GetAllDriverUrls()
    {
      //1. Load danh sách các driver info có trong máy tính
      DriveInfo[] driverInfo = GetAllDrivers();

      //2. Nếu không có driver nào thì trả về null
      if (driverInfo == null)
        return null;

      //3. Trích lọc driver url từ các folder info
      var driverUrlList = from item in driverInfo
                          select item.Name;

      //4. Trả kết quả về dạng mảng
      return driverUrlList.ToArray();
    }
  }

  public static class ImageUtility
  {
    #region Helpers
    /// <summary>
    /// Tìm Image Code theo tên.
    /// Trả về ImageCode tìm thấy. Nếu không tìm thấy thì trả về null.
    /// </summary>
    /// <param name="mimeType">Loại file. Ví dụ: image/jpeg hoặc image/gif hoặc image/png.</param>
    /// <returns>Trả về ImageCode tìm thấy. Nếu không tìm thấy thì trả về null.</returns>
    private static ImageCodecInfo GetEncoderInfo(string mimeType)
    {
      //1. Chuyển mimeType sang dạng chữ thường
      mimeType = mimeType.ToLower();

      //2. Liệt kê danh sách các image code có thể có
      ImageCodecInfo[] codes = ImageCodecInfo.GetImageEncoders();

      //3. Lặp qua từng code trong danh sách
      for (int i = 0; i < codes.Length; i++)
      {
        //So sánh, nếu có tên giống nhau thì trả kết quả về
        if (codes[i].MimeType.ToLower() == mimeType)
          return codes[i];
      }

      //4. Nếu chạy hết vòng lặp mà vẫn không tìm thấy, thì trả về null
      return null;
    }

    /// <summary>
    /// Tính toán tọa độ đặt WaterMask
    /// </summary>
    /// <param name="waterMaskPositionType">Kiểu tọa độ đặt WaterMask.</param>
    /// <param name="sourceSize.Width">Chiều dài ảnh ban đầu.</param>
    /// <param name="sourceSize.Height">Chiều cao ảnh ban đầu.</param>
    /// <param name="waterMaskSize">Chiều dài ảnh làm WaterMask.</param>
    /// <param name="newWaterMaskHeight">Chiều cao ảnh làm WaterMask.</param>
    /// <param name="waterMaskMargin">Khoảng cách lề 4 cạnh của WaterMask so với biên của ảnh ban đầu.</param>
    /// <param name="waterMaskPoint.X">Tạo độ X của WaterMask.</param>
    /// <param name="waterMaskPoint.Y">Tạo độ Y của WaterMask.</param>
    private static void GetWaterMaskPosition(WaterMaskPositionType waterMaskPositionType, Size sourceSize, Size waterMaskSize, int waterMaskMargin, ref Point waterMaskPoint)
    {
      switch (waterMaskPositionType)
      {
        case WaterMaskPositionType.TopLeft:
          waterMaskPoint.X = waterMaskMargin;
          waterMaskPoint.Y = waterMaskMargin;
          break;
        case WaterMaskPositionType.TopRight:
          waterMaskPoint.X = sourceSize.Width - waterMaskSize.Width - waterMaskMargin;
          waterMaskPoint.Y = waterMaskMargin;
          break;
        case WaterMaskPositionType.BottomRight:
          waterMaskPoint.X = sourceSize.Width - waterMaskSize.Width - waterMaskMargin;
          waterMaskPoint.Y = sourceSize.Height - waterMaskSize.Height - waterMaskMargin;
          break;
        case WaterMaskPositionType.BottomLeft:
          waterMaskPoint.X = waterMaskMargin;
          waterMaskPoint.Y = sourceSize.Height - waterMaskSize.Height - waterMaskMargin;
          break;
        case WaterMaskPositionType.MiddleCenter:
        default:
          waterMaskPoint.X = ((sourceSize.Width - waterMaskSize.Width) / 2F).RoundToInt();
          waterMaskPoint.Y = ((sourceSize.Height - waterMaskSize.Height) / 2F).RoundToInt();
          break;
      }
    }

    /// <summary>
    /// Trả về đối tượng ImageAttributes có hỗ trợ độ trong suốt
    /// </summary>
    /// <param name="opacityPecent">Độ trong suốt của hình. Có giá trị nằm trong khoảng 0 - 100</param>
    /// <returns>Trả về đối tượng ImageAttributes có hỗ trợ độ trong suốt</returns>
    private static ImageAttributes GetImageAttributes(int opacityPecent)
    {
      //1. Chuyển độ trong suốt từ số nguyên sang dạng phần trăm
      float alphaPercent = opacityPecent / 100F;

      //2. Tạo một đối tượng để thiết lập các thuộc tính của ảnh
      ImageAttributes imageAttributes = new ImageAttributes();
      ColorMap colorMap = new ColorMap();
      colorMap.OldColor = Color.FromArgb(255, 0, 255, 0);
      colorMap.NewColor = Color.FromArgb(0, 0, 0, 0);
      ColorMap[] mapTable = { colorMap };

      //3. Thiết lập độ trong suốt cho ảnh (chú ý vị trí của alphaPercent)
      float[][] colorMatrixElements = {   new float[] {1.0f,  0.0f,  0.0f,  0.0f, 0.0f},
                                        new float[] {0.0f,  1.0f,  0.0f,  0.0f, 0.0f},
                                        new float[] {0.0f,  0.0f,  1.0f,  0.0f, 0.0f},
                                        new float[] {0.0f,  0.0f,  0.0f,  alphaPercent, 0.0f},
                                        new float[] {0.0f,  0.0f,  0.0f,  0.0f, 1.0f}
                                    };

      //4. Thiết lập các thuộc tính của ảnh
      ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
      imageAttributes.SetRemapTable(mapTable, ColorAdjustType.Bitmap);
      imageAttributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

      //5. Trả về đối tượng đã được thiết lập đầy đủ các thông số.
      return imageAttributes;
    }

    /// <summary>
    /// Tạo một hình Bitmap sử dụng văn bản và các tham số hình.
    /// </summary>
    /// <param name="text">Văn bản cần hiển thị.</param>
    /// <param name="fontUrl">Đường dẫn đến font. Cần sử dụng Font thuộc họ Unicode.</param>
    /// <param name="fontStyle">Kiểu Font: , bình thường, in đậm, in nghiêng hoặc gạch chân.</param>
    /// <param name="textColor1">Màu chữ số 1. Dùng để hòa trộn với Màu chữ số 2.</param>
    /// <param name="textColor2">Màu chữ số 2. Dùng để hòa trộn với Màu chữ số 1.</param>
    /// <param name="backgroundColor">Màu nền của ảnh.</param>
    /// <param name="borderColor">Màu khung.</param>
    /// <param name="borderSize">Cỡ khung. Đơn vị là px</param>
    /// <param name="gradientAngle">Góc hòa trộn màu sử dụng Gradient</param>
    /// <returns></returns>
    private static Bitmap CreateBitmapImageFromText(string text, string fontUrl, FontStyle fontStyle, Color textColor1, Color textColor2, Color backgroundColor, Color borderColor, int borderSize, int gradientAngle)
    {
      //1. Định nghĩa cỡ font thật lớn thu được hình có độ phân giải cao.
      //Lưu ý: chỉ nên thiết lập khoảng 1000 trở lại, nếu lớn hơn có thể gây ra lỗi.
      int fontSize = 1000;

      //2. Tạo font chữ cá nhân từ file Font, fontSize, và fontStyle.
      Font font = CreatePrivateFont(fontUrl, fontSize, fontStyle);

      //3. Tạo ảnh Bitmap trong suốt có kích cỡ phù hợp với nội dung và cỡ chữ.
      Bitmap bitmap = CreateEmptyBitmap(text, font);

      //4. Tạo một đối tượng xử lý ảnh.
      Graphics graphic = Graphics.FromImage(bitmap);

      //5. Thiết lập màu nền cho ảnh
      graphic.Clear(backgroundColor);

      //6. Thiết lập các thông số chất lượng.
      graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
      graphic.SmoothingMode = SmoothingMode.HighQuality;
      graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
      graphic.CompositingQuality = CompositingQuality.HighQuality;

      //7. Thiết lập thông số tối ưu dành cho văn bản
      graphic.TextRenderingHint = TextRenderingHint.AntiAlias;

      //8. Thiết lập kiểu viền bao quan chữ
      Pen pen = new Pen(borderColor, borderSize);
      pen.LineJoin = LineJoin.Round;

      //9. Thiết lập hiệu ứng chuyển sắc Gradient cho vùng chọn
      //9.1 Tạo vùng chọn bọc hết phần chữ
      Rectangle rectangleGradient = new Rectangle(0, bitmap.Height - font.Height, bitmap.Width, font.Height);
      //9.2. Thiết lập hiệu ứng chuyển sắc Gradient cho vùng chọn
      LinearGradientBrush linearGradientBrush = new LinearGradientBrush(rectangleGradient, textColor1, textColor2, gradientAngle);

      //10. Định dạng canh giữa chữ cả 2 chiều ngang-dọc
      StringFormat stringFormat = new StringFormat();
      stringFormat.Alignment = StringAlignment.Center;
      stringFormat.LineAlignment = StringAlignment.Center;

      //11. Tạo đối tượng GraphicsPath để xử lý chữ
      GraphicsPath textGraphicsPath = new GraphicsPath();

      //12. Tạo vùng chọn để đặt chữ vào.
      Rectangle textRectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);

      //13. Chèn chữ vào vùng chọn.
      textGraphicsPath.AddString(text, font.FontFamily, (int)fontStyle, fontSize, textRectangle, stringFormat);

      //14. Tạo hiệu ứng Gradient.
      graphic.FillPath(linearGradientBrush, textGraphicsPath);

      //15. Tạo hiệu ứng chữ có viền xung quanh.
      graphic.DrawPath(pen, textGraphicsPath);

      //16. Trả về hình được tạo ra từ văn bản với các thông số đã chọn
      return bitmap;
    }

    /// <summary>
    /// Tạo một ảnh Bimap rỗng, có chiều dài x chiều cao phù hợp với nội dung và font chữ.
    /// </summary>
    /// <param name="text">Chuỗi cần tạo hình động.</param>
    /// <param name="font">Font chữ cho chuỗi cần tạo hình động.</param>
    /// <returns></returns>
    private static Bitmap CreateEmptyBitmap(string text, Font font)
    {
      //1. Cộng thêm một khoảng trắng vào 2 đầu văn bản để tránh tình trạng bị che mất 1 ký tự đầu hoặc cuối
      text = " " + text + " ";

      //2. Tạo một hình Bitmap rỗng có kích cỡ tối thiểu 1px
      Bitmap bitmap = new Bitmap(1, 1);

      //3. Tạo một đối tượng xử lý ảnh
      Graphics graphic = Graphics.FromImage(bitmap);

      //4. Tính toán kích cỡ của ảnh dựa trên font và độ dài văn bản
      SizeF autoSizeFont = graphic.MeasureString(text, font);

      //5. Thiết lập kích cỡ mới cho ảnh
      bitmap = new Bitmap((int)autoSizeFont.Width, (int)autoSizeFont.Height);

      //6. Trả về ảnh Bitmap đúng kích cỡ. Ảnh này còn trong suốt, chưa có màu sắc gì.
      return bitmap;
    }

    /// <summary>
    /// Tạo một Font chữ cá nhân từ một file font chữ bất kỳ.
    /// Trả về font chữ đúng với các cấu hình.
    /// </summary>
    /// <param name="url">Đường dẫn đến file font. Ví dụ: ../../UVNDUNGDAN.TTF</param>
    /// <param name="fontSize">Cỡ font. Nằm trong khoảng 1 - 1000</param>
    /// <param name="fontStyle">Kiểu chữ. Regular: bình thường; Bold: in đậm; Italic: nghiêng; Underline: gạch chân.</param>
    /// <returns>Trả về font chữ đúng với các cấu hình.</returns>
    private static Font CreatePrivateFont(string url, int fontSize, FontStyle fontStyle)
    {
      //1. Tạo Font chữ cá nhân
      PrivateFontCollection privteFont = new PrivateFontCollection();

      //2. Thiết lập font từ URL
      privteFont.AddFontFile(url);

      //3. Tạo một fontFamily
      FontFamily fontFamily = privteFont.Families[0];

      //4. Cấu hình các tham số cho font
      Font font = new Font(fontFamily, fontSize, fontStyle, GraphicsUnit.Pixel);

      //5. Trả về kết quả
      return font;
    }
    #endregion

    #region Methods
    /// <summary>
    /// Load ảnh Bitmap từ Url.
    /// Trả về ảnh có dạng Bitmap.
    /// </summary>
    /// <param name="url">Vị trí dẫn đến file ảnh.</param>
    /// <returns>Trả về ảnh có dạng Bitmap.</returns>
    public static Bitmap LoadImage(string url)
    {
      Bitmap bitmap = new Bitmap(url);
      return bitmap;
    }

    /// <summary>
    /// Thay đổi kích cỡ của ảnh.
    /// </summary>
    /// <param name="sourceImage">Ảnh cần thay đổi kích cỡ.</param>
    /// <param name="newWidth">Chiều dài mới.</param>
    /// <param name="newHeight">Chiều cao mới.</param>
    /// <param name="fitSizeType">
    /// Độ ưu tiên khi tỷ lệ của chiều dài mới và chiều cao mới không tương đồng với nhau.
    /// </param>
    /// <returns>Trả về ảnh với kích cỡ mới.</returns>
    public static Bitmap ResizeImage(Bitmap sourceImage, int size, FitSizeType fitSizeType)
    {
      //1. Lấy chiều dài ban đầu của ảnh.
      int sourceWidth = sourceImage.Width;
      //2. Lấy chiều cao ban đầu của ảnh.
      int sourceHeight = sourceImage.Height;

      //3. Khai báo chiều dài mới và chiều cao mới
      int newWidth = 0;
      int newHeight = 0;

      //4. Kiểm tra độ ưu tiên để thiết lập kích cỡ mới
      if (fitSizeType == FitSizeType.Width)
      {
        newWidth = size;
        newHeight = ((sourceHeight * newWidth) / sourceWidth.ToFloat()).RoundToInt();
      }
      else
      {
        newHeight = size;
        newWidth = ((sourceWidth * newHeight) / sourceHeight.ToFloat()).RoundToInt();
      }

      //5. Tạo một đối tượng Bitmap có kích cỡ theo tỷ lệ.
      Bitmap newImage = new Bitmap(newWidth, newHeight);

      //6. Tạo một đối tượng xử lý ảnh
      Graphics graphic = Graphics.FromImage(newImage);

      //7. Thiết lập chất lượng ảnh là cao nhất
      graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;

      //8. Tạo ảnh mới với kích cỡ mới
      graphic.DrawImage(sourceImage, 0, 0, newWidth, newHeight);

      //9. Giải phóng bộ nhớ, của đối tượng graphic
      graphic.Dispose();

      //10. Trả về kết quả
      return newImage;
    }

    /// <summary>
    /// Lưu ảnh thành file.
    /// Có thể tùy chọn loại ảnh (jpg|png|gif|v.v..) theo url, tùy chọn resolution và tùy chọn chất lượng ảnh.
    /// </summary>
    /// <param name="sourceImage">Ảnh cần lưu thành file.</param>
    /// <param name="quality">Chất lượng của ảnh sau khi lưu.</param>
    /// <param name="url">Vị trí sẽ lưu ảnh.
    /// Vd: C:\Images\abc.jpeg
    /// </param>
    /// <returns>Kết quả của việc lưu hình.
    /// True: lưu hình thành công; False: lưu hình không thành công.
    /// </returns>
    public static bool SaveImage(Bitmap sourceImage, float resolution, int quality, string url)
    {
      //1. Lấy đuôi hình từ url để save cho đúng kiểu
      string extension = Path.GetExtension(url);

      //2. Nếu đuôi có dạng jpg thì đổi thành jpeg cho đúng chuẩn
      extension = extension.Replace("jpg", "jpeg");

      //3. Thay đuôi có dạng .xyz thành image/xyz
      extension = extension.Replace(".", "image/");

      //4. Thiết lập kiểu hình khi lưu trữ
      ImageCodecInfo imageCode = GetEncoderInfo(extension);

      //5. Nếu loại hình không hợp lệ thì kết thúc
      if (imageCode == null)
        return false;

      //6. Thiết lập chất lượng khi lưu trữ
      EncoderParameter qualityParam = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);

      //7. Đưa tham số vào trong danh sách tham số
      EncoderParameters encoderParams = new EncoderParameters(1);
      encoderParams.Param[0] = qualityParam;

      //8. Tạo một ảnh mới có kích cỡ như hình ban đầu
      Bitmap newImage = new Bitmap(sourceImage.Width, sourceImage.Height);

      //9. Thiết lập Resolution cho hình mới
      newImage.SetResolution(resolution, resolution);

      //10. Tạo 1 đối tượng xử lý ảnh
      Graphics graphic = Graphics.FromImage(newImage);

      //11. Thiết lập các thông số ảnh
      graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
      graphic.SmoothingMode = SmoothingMode.HighQuality;
      graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
      graphic.CompositingQuality = CompositingQuality.HighQuality;

      //12. Tạo ảnh mới với kích cỡ mới
      graphic.DrawImage(sourceImage, 0, 0, sourceImage.Width, sourceImage.Height);

      //13. Giải phóng bộ nhớ của đối tượng graphic
      graphic.Dispose();

      //14. Lưu ảnh đúng vị trí, định dạng và chất lượng.
      newImage.Save(url, imageCode, encoderParams);

      //15. Trả về thành công
      return true;
    }

    /// <summary>
    /// Xoay ảnh một góc tùy ý theo RotateFlipType. Trả về ảnh sau khi đã xoay.
    /// </summary>
    /// <param name="sourceImage">Ảnh cần xoay.</param>
    /// <param name="rotateFlipType">Góc xoay.</param>
    /// <returns>Trả về ảnh sau khi đã xoay.</returns>
    public static Bitmap RotateImage(Bitmap sourceImage, RotateFlipType rotateFlipType)
    {
      //1. Tạo một ảnh mới bằng cách nhân bản từ ảnh ban đầu.
      Bitmap newImage = sourceImage.Clone() as Bitmap;

      //2. Xoay ảnh theo kiểu xoay đã chọn
      newImage.RotateFlip(rotateFlipType);

      //3. Trả về kết quả
      return newImage;
    }

    /// <summary>
    /// Xoay ảnh sang trái một góc 90 độ. Trả về ảnh sau khi đã xoay.
    /// </summary>
    /// <param name="sourceImage">Ảnh cần xoay.</param>
    /// <returns>Trả về ảnh sau khi đã xoay.</returns>
    public static Bitmap RotateImageToLeft(Bitmap sourceImage)
    {
      return RotateImage(sourceImage, RotateFlipType.Rotate90FlipXY);
    }

    /// <summary>
    /// Xoay ảnh sang phải một góc 90 độ. Trả về ảnh sau khi đã xoay.
    /// </summary>
    /// <param name="sourceImage">Ảnh cần xoay.</param>
    /// <returns>Trả về ảnh sau khi đã xoay.</returns>
    public static Bitmap RotateImageToRight(Bitmap sourceImage)
    {
      return RotateImage(sourceImage, RotateFlipType.Rotate90FlipNone);
    }

    /// <summary>
    /// Đóng dấu lên ảnh sử dụng hình làm WaterMask.
    /// Trả về ảnh đã được đóng dấu sử dụng văn bản làm WaterMask.
    /// </summary>
    /// <param name="sourceImage">Ảnh ban đầu.</param>
    /// <param name="waterMaskImage">Ảnh dùng làm WaterMask.</param>
    /// <param name="waterMaskOpacityPecent">Độ rõ của WaterMask. Đơn vị tính là %. Tối thiểu : 0; Tối đa 100</param>
    /// <param name="waterMaskRatio">Tỉ lệ kích cỡ của WaterMask so với ảnh ban đầu. Đơn vị tính là %. Tối thiểu : 0; Tối đa 100</param>
    /// <param name="waterMaskPositionType">Vị trí đặt WaterMask trên ảnh ban đầu.</param>
    /// <param name="waterMaskMargin">Khoảng cách lề 4 cạnh của WaterMask so với biên của ảnh ban đầu. Không áp dụng khi thiết lập WaterMaskPositionType = MiddleCenter</param>
    /// <returns>Trả về ảnh đã được đóng dấu sử dụng WaterMask.</returns>
    public static Bitmap WaterMaskWithImage(Bitmap sourceImage, Bitmap waterMaskImage, int waterMaskOpacityPecent, int waterMaskRatio, WaterMaskPositionType waterMaskPositionType, int waterMaskMargin)
    {
      //1. Lấy kích cỡ thật của ảnh ban đầu
      Size sourceSize = sourceImage.Size;

      //2. Lấy kích cỡ thật của ảnh WaterMask
      Size sourceWaterMaskSize = waterMaskImage.Size;

      //3. Tính lại kích cỡ mới của WaterMask theo tỉ lệ
      Size waterMaskSize = new Size();
      waterMaskSize.Width = (sourceSize.Width * waterMaskRatio / 100F).RoundToInt();
      waterMaskSize.Height = (sourceWaterMaskSize.Height * waterMaskSize.Width / sourceWaterMaskSize.Width.ToFloat()).RoundToInt();

      //4. Resize ảnh WaterMask theo tỉ lệ
      waterMaskImage = ResizeImage(waterMaskImage, waterMaskSize.Width, FitSizeType.Width);

      //5. Tạo một ảnh mới có kích cỡ như ảnh ban đầu để lưu kết quả
      Bitmap newImage = new Bitmap(sourceSize.Width, sourceSize.Height, PixelFormat.Format24bppRgb);

      //6. Thiết lập độ phân giải của ảnh mới giống như ảnh ban đầu
      newImage.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);

      //7. Tạo một đối tượng xử lý ảnh
      Graphics graphic = Graphics.FromImage(newImage);

      //8. Thiết lập chất lượng là tốt nhất
      graphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
      graphic.SmoothingMode = SmoothingMode.HighQuality;
      graphic.PixelOffsetMode = PixelOffsetMode.HighQuality;
      graphic.CompositingQuality = CompositingQuality.HighQuality;

      //9. Copy ảnh ban đầu lên ảnh mới (layer 1)
      graphic.DrawImage(sourceImage, new Rectangle(0, 0, sourceSize.Width, sourceSize.Height), 0, 0, sourceSize.Width, sourceSize.Height, GraphicsUnit.Pixel);

      //10. Xử lý độ trong suốt của WaterMask
      ImageAttributes imageAttributes = GetImageAttributes(waterMaskOpacityPecent);

      //11. Tính toán tọa độ bắt đầu đặt WaterMask trên ảnh
      Point waterMaskPoint = new Point(0, 0);
      GetWaterMaskPosition(waterMaskPositionType, sourceSize, waterMaskSize, waterMaskMargin, ref waterMaskPoint);

      //12. Tính toán khu vực đặt WaterMask
      Rectangle waterMaskRectangle = new Rectangle();
      waterMaskRectangle.X = waterMaskPoint.X;
      waterMaskRectangle.Y = waterMaskPoint.Y;
      waterMaskRectangle.Width = waterMaskSize.Width;
      waterMaskRectangle.Height = waterMaskSize.Height;

      //13. Đóng dấu Watermark lên ảnh
      graphic.DrawImage(waterMaskImage, waterMaskRectangle, 0, 0, waterMaskSize.Width, waterMaskSize.Height, GraphicsUnit.Pixel, imageAttributes);

      //14. Trả về kết quả
      return newImage;
    }

    /// <summary>
    /// Đóng dấu lên ảnh sử dụng văn bản làm WaterMask.
    /// Trả về ảnh đã được đóng dấu sử dụng văn bản làm WaterMask.
    /// </summary>
    /// <param name="sourceImage">Ảnh ban đầu.</param>
    /// <param name="text">Văn bản dùng làm WaterMask</param>
    /// <param name="fontUrl">Đường dẫn đến font của văn bản dùng làm WaterMask</param>
    /// <param name="waterMaskOpacityPecent">Độ rõ của WaterMask. Đơn vị tính là %. Tối thiểu : 0; Tối đa 100</param>
    /// <param name="waterMaskRatio">Tỉ lệ kích cỡ của WaterMask so với ảnh ban đầu. Đơn vị tính là %. Tối thiểu : 0; Tối đa 100</param>
    /// <param name="waterMaskPositionType">Vị trí đặt WaterMask trên ảnh ban đầu.</param>
    /// <param name="waterMaskMargin">Khoảng cách lề 4 cạnh của WaterMask so với biên của ảnh ban đầu. Không áp dụng khi thiết lập WaterMaskPositionType = MiddleCenter</param>
    /// <param name="fontStyle">Kiểu Font. Regular: bình thường; Bold: in đậm; Italic: in nghiêng; Underline: gạch chân; Strikeout: gạch ngang.</param>
    /// <param name="textColor1">Màu chữ 01.</param>
    /// <param name="textColor2">Màu chữ 02.</param>
    /// <param name="gradientAngle">Góc hòa trộn màu chữ 01 và màu chữ 02. Giá trị nằm trong khoảng 0 - 360.</param>
    /// <param name="backgroundColor">Màu nền</param>
    /// <param name="borderColor">Màu đường viền bo quanh chữ.</param>
    /// <param name="borderSize">Cỡ đường viền bo quanh chữ.</param>
    /// <returns>Trả về ảnh đã được đóng dấu sử dụng văn bản làm WaterMask.</returns>
    public static Bitmap WaterMaskWithString(Bitmap sourceImage, string text, string fontUrl, int maskOpacityPecent, int waterMaskRatio, WaterMaskPositionType waterMaskPosition, int waterMaskMargin, FontStyle fontStyle, Color textColor1, Color textColor2, int gradientAngle, Color backgroundColor, Color borderColor, int borderSize)
    {
      //Tạo một hình Bitmap sử dụng văn bản và các thông số.
      Bitmap textBitmap = CreateBitmapImageFromText(text, fontUrl, fontStyle, textColor1, textColor2, backgroundColor, borderColor, borderSize, gradientAngle);
      //Đóng dấu lên hình
      return WaterMaskWithImage(sourceImage, textBitmap, maskOpacityPecent, waterMaskRatio, waterMaskPosition, waterMaskMargin);
    }

    /// <summary>
    /// Cắt cúp ảnh tại 1 vùng được chọn.
    /// Trả về ảnh mới được tạo ra từ vùng chọn cắt cúp.
    /// </summary>
    /// <param name="sourceImage">Ảnh cần được cắt cúp.</param>
    /// <param name="rectangle">Khu vực cần được cắt cúp.</param>
    /// <returns>Trả về ảnh mới được tạo ra từ vùng chọn cắt cúp.</returns>
    public static Bitmap CropImage(Bitmap sourceImage, Rectangle rectangle)
    {
      //1. Tạo một ảnh mới có kích cỡ vừa bằng khu vực cần cắt cúp ảnh
      Bitmap newImage = new Bitmap(rectangle.Width, rectangle.Height);

      //2. Tạo một đối tượng xử lý ảnh
      Graphics graphics = Graphics.FromImage(newImage);

      //3. Tô màu lên ảnh mới với dữ liệu được chọn từ ảnh ban đầu tại khu vực cần cắt cúp ảnh
      graphics.DrawImage(sourceImage, 0, 0, rectangle, GraphicsUnit.Pixel);

      //4. Trả về ảnh mới
      return newImage;
    }
    #endregion
  }


}

