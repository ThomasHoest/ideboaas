/**
 * Created by Thomas on 16-08-2014.
 */

var page = new function(){  
  this.initialize = function () {
    var calender = $('#calendar-anchor').fullCalendar({
      aspectRatio: 3,
      events: bookings
    });
    
    $('#save-booking').click(function() {
      var booking = {
        from : $('#booking-from').text(),
        to : $('#booking-to').text(),
        title: "booking",
        color : 'blue'
      }
    });

  }
}


