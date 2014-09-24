/**
 * Created by Thomas on 16-08-2014.
 */

var page = new function(){  
  this.initialize = function () {
    $('#calendar-anchor').fullCalendar({
      aspectRatio: 3,
      events: [
        {
          title: 'Some booking',
          start: '2014-08-17',
          end: '2014-08-27',
          color: 'blue'
        }
      ]
    });
  }
}


