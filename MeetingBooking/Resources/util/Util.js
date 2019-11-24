
//Loading bar
var ShowLoadingBar = function () {
  NProgress.inc();
};

var HideLoadingBar = function () {
  setTimeout(function () {
    NProgress.done();
  }, 1500);
};

var FadeLoadingBar = function () {
  ShowLoadingBar();
  HideLoadingBar();
};

//LoadingDelay

var HideLoading = function (timeDelay = 350, timeOut = 350) {
  $("#main-loading-delay").delay(timeDelay).fadeOut(timeOut);
};

var ShowLoading = function (timeOut = 350) {
  $("#main-loading-delay").fadeIn(timeOut);
};

var FadeLoading = function (timeOut = 350) {
  $("#main-loading-delay").fadeIn().fadeOut(timeOut);
};

//Alert
var Alert = function (title, icon, type, content) {
  $.alert({
    title: title,//Error,success..
    icon: icon,//Font Awesome
    type: type,//Green..
    content: content,
    theme: "modern",
    buttons: {
      OK: {
        text: "Đã hiểu",
        btnClass: "btn-red"
      }
    }
  });
};

var AlertDanger = function (content) {
  $.confirm({
    icon: "fa fa-frown-o",
    theme: "modern",
    title: "Thông báo !",
    closeIcon: true,
    content: content,
    animation: "scale",
    type: "red",
    buttons: {
      Đóng: {
        text: "Đã hiểu",
        btnClass: "btn-dark"
      }
    }
  });
};

var AlertSuccess = function (content) {
  $.confirm({
    icon: "fa fa-check",
    theme: "modern",
    title:"Thông báo !",
    closeIcon: true,
    content: content,
    animation: "scale",
    type: "green",
    buttons: {
      Đóng: {
        text: "Đã hiểu",
        btnClass: "btn-dark"
      }
    }
  });
};

var AlertWarning = function (content) {
  $.confirm({
    icon: "fa fa-warning",
    theme: "modern",
    title: "Thông báo !",
    closeIcon: true,
    content: content,
    animation: "scale",
    type: "orange",
    buttons: {
      Đóng: {
        text: "Đã hiểu",
        btnClass: "btn-dark"
      }
    }
  });
};

var ConverPrice = function (price, type) {
  if (price === null || price === 0) {
    return "0" + type;
  }
  price = price.toString();
  var n = price
    .split("")
    .reverse()
    .join("");
  var n2 = n.replace(/\d\d\d(?!$)/g, "$&.");
  return (
    n2
      .split("")
      .reverse()
      .join("") + type
  );
};
//Loading
var LoadingShow = function (timeOut = 0) {
  $("#main-loading").fadeIn(timeOut);
};

var LoadingHide = function (timeOut = 0) {
  $("#main-loading").fadeOut(timeOut);
};

var Calendar = {
  Init: function (data) {
    this.Register(data);
  },
  Register: function (data) {
    $('#calendar').fullCalendar({
      weekends: false // will hide Saturdays and Sundays
    });

    //document.addEventListener('DOMContentLoaded', function () {
    //  var initialLocaleCode = 'vi';
    //  var calendarEl = document.getElementById('calendar');
    //  var calendar = new FullCalendar.Calendar(calendarEl, {
    //    plugins: ['interaction', 'dayGrid', 'timeGrid'],
    //    header: {
    //      left: 'prev,next today',
    //      center: 'title',
    //      right: 'dayGridMonth,timeGridWeek,timeGridDay'
    //    },
    //    defaultDate: '2019-04-12',
    //    navLinks: true, // can click day/week names to navigate views
    //    selectable: true,
    //    selectMirror: true,
    //    locale: initialLocaleCode,
    //    select: function (arg) {
    //      var title = prompt('Event Title:');
    //      if (title) {
    //        calendar.addEvent({
    //          title: title,
    //          start: arg.start,
    //          end: arg.end,
    //          allDay: arg.allDay
    //        })
    //      }
    //      calendar.unselect()
    //    },
    //    editable: true,
    //    eventLimit: true, // allow "more" link when too many events
    //    eventClick: function (arg) {
    //      console.log(arg)
    //      $("#detailBooking").modal("show");
    //    },
    //    events: data
    //  });

    //  calendar.render();
    //});
  }
};

var DateTimeFormat = {
  GetDate: function (dateTime) {
    var nowDate = new Date(parseInt(dateTime.substr(6)));
    return nowDate.format("dd/mm/yyyy");
  },
  GetTime: function (dateTime) {
    var nowDate = new Date(parseInt(dateTime.substr(6)));
    return nowDate.format("HH:MM");
  },
  GetFullTime: function (dateTime) {
    var nowDate = new Date(parseInt(dateTime.substr(6)));
    return nowDate.format("HH:MM:ss");
  },
  GetDateTime: function (dateTime) {
    var nowDate = new Date(parseInt(dateTime.substr(6)));
    return nowDate.format("dd/mm/yyyy -- HH:MM:ss");
  }
};

var Tooltip = {
  Init: function (className, dataInput) {
    $(className).tooltipster({
      content: dataInput,
      contentCloning: true,
      contentAsHTML: true,
      interactive: true,
      functionInit: function (instance, helper) {
        var data = instance.content();
        if (data != 0) {
          let result = "";
          data.map(res => {
            let temp = `
                     <li>
                        <span class="handle ui-sortable-handle">
                          <i class="fa fa-ellipsis-v"></i>
                          <i class="fa fa-ellipsis-v"></i>
                        </span>
                        <span class="text">{name}</span>
                        <small class="badge bg-yellow pull-right"><i class="fa fa-refresh"></i> &nbspCòn {quantity} SP</small>

                      </li>
                `;
            result += temp.replace("{name}", res.FoodName).replace("{quantity}", res.Quantity);
          });

          let resultAll = `<ul class="todo-list ui-sortable">` + result + `</ul>`;

          instance.content(resultAll);
        }
        else {
          instance.content("Không có sản phẩm nào");
        }
      }
    });
  }
};

var JSONDateWithTime = function (dateStr) {
  jsonDate = dateStr;
  var d = new Date(parseInt(jsonDate.substr(6)));
  var m, day;
  m = d.getMonth() + 1;
  if (m < 10)
    month = '0' + m;
  if (d.getDate() < 10)
    day = '0' + d.getDate();
  else
    day = d.getDate();

  var year = d.getFullYear();
  var formattedDate = day + "/" + month + "/" + year;
  var hours = (d.getHours() < 10) ? "0" + d.getHours() : d.getHours();
  var minutes = (d.getMinutes() < 10) ? "0" + d.getMinutes() : d.getMinutes();
  var seconds = d.getSeconds();
  var formattedTime = hours + ":" + minutes;
  formattedDate = formattedTime + " - " + formattedDate;

  //Ngày giờ hiện tại
  var dateObj = new Date();
  var dayNow = dateObj.getDate();
  var monthNow = dateObj.getMonth() + 1;
  var yearNow = dateObj.getFullYear();
  var hoursNow = dateObj.getHours();
  var minutesNow = dateObj.getMinutes();
  var secondsNow = dateObj.getSeconds();

  dateObj = formattedDate;

  if (hoursNow - hours == 0 && minutesNow - minutes == 0 && yearNow - year == 0 && monthNow - month == 0 && dayNow - day == 0) {
    dateObj = secondsNow - seconds + " giây trước";
  }

  if (hoursNow - hours == 0 && minutesNow - minutes > 0 && yearNow - year == 0 && monthNow - month == 0 && dayNow - day == 0) {
    dateObj = minutesNow - minutes + " phút trước";
  }

  if (hoursNow - hours > 0 && yearNow - year == 0 && monthNow - month == 0 && dayNow - day == 0) {
    dateObj = hoursNow - hours + " giờ trước";
  }

  if (yearNow - year == 0 && monthNow - month == 0 && dayNow - day > 0 && dayNow - day <= 7) {
    dateObj = dayNow - day + " ngày trước";
  }

  if (yearNow - year == 0 && monthNow != month) {
    var day = dayNow - day;
    var month = monthNow - month;
    day = month * 30 + day;
    if (0 < day && day <= 7) {
      dateObj = day + " Ngày trước";
    }
  }
  return dateObj;
};

var convert = function (d) {
  return (
    d.constructor === Date ? d :
      d.constructor === Array ? new Date(d[0], d[1], d[2]) :
        d.constructor === Number ? new Date(d) :
          d.constructor === String ? new Date(d) :
            typeof d === "object" ? new Date(d.year, d.month, d.date) :
              NaN
  );
};

var Compare = function (a, b) {
  //  -1 : if a < b
  //   0 : if a = b
  //   1 : if a > b
  return (
    isFinite(a = this.convert(a).valueOf()) &&
      isFinite(b = this.convert(b).valueOf()) ?
      (a > b) - (a < b) :
      NaN
  );
};

var Chart = {
  Init: function (dataChart) {
    this.Register(dataChart);
  },
  Register: function (dataChart) {
    //Khởi tạo chart
    Highcharts.chart('container', {
      chart: {
        type: 'column'
      },
      title: {
        text: 'Biểu đồ thống kê số liệu cuộc họp năm'
      },
      subtitle: {
        text: 'Số liệu hiển thị của từng phòng cụ thể: <a href="https://www.facebook.com/ngocsonit195" target="_blank"></a>'
      },
      xAxis: {
        type: 'category'
      },
      yAxis: {
        title: {
          text: 'Biểu đồ thống kê cuộc họp create by Son IT 2019'
        }

      },
      legend: {
        enabled: false
      },
      plotOptions: {
        series: {
          borderWidth: 0,
          dataLabels: {
            enabled: true,
            format: '{point.y:.1f} Lần'
          }
        }
      },

      tooltip: {
        headerFormat: '<span style="font-size:11px">{series.name}</span><br>',
        pointFormat: '<span style="color:{point.color}">{point.name}</span>: <b>{point.y:.2f}</b> cuộc họp<br/>'
      },

      series: [
        {
          name: "Thống kê ngày",
          colorByPoint: true,
          data: dataChart
        }
      ]

    });
  }
};

var FormatDate = {
  GetFormattedDate: function () {
    var todayTime = new Date();
    var month = format(todayTime.getMonth() + 1);
    var day = format(todayTime.getDate());
    var year = format(todayTime.getFullYear());
    return month + "/" + day + "/" + year;
  }
};

