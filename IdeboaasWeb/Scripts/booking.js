/**
 * Created by Thomas on 16-08-2014.
 */

var page = new function(){  
  this.initialize = function () {
    var calender = $('#calendar-anchor').fullCalendar({
      aspectRatio: 3,
      events: bookings
    });
    
    $('#save-booking').on('click',function() {
      var booking = {
        start: $('#booking-from').text(),
        end: $('#booking-to').text(),
        title: "booking",
        color: 'blue'
      };

      $.post("Booking/book", booking, function() {
        
      });
    });

  }
}


