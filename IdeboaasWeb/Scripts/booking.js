/**
 * Created by Thomas on 16-08-2014.
 */

var page = new function () {
    var page = this;
    this._currentBooking = {};

    this.selection = function (start, end) {
        page._currentBooking = {
            start: start.format("YYYY-MM-DD"),
            end: end.format("YYYY-MM-DD")
        }

        $("#current-booking").first().text(start.format("DD-MM-YYYY") + " - " + end.format("DD-MM-YYYY"));
    }

    this.initialize = function () {
        var calender = $('#calendar-anchor').fullCalendar({
            aspectRatio: 3,
            events: bookings,
            selectable: true,
            select: this.selection
        });
        var self = this;
        $('#save-booking').on('click', function () {
            if (self._currentBooking.start) {
                var name = $("#booking-name")[0].value;
                var type = $("#booking-type option:selected").text();
                self._currentBooking.title = name;
                self._currentBooking.color = type;
                $.post("Booking/book", self._currentBooking, function() {

                });
            } else {
                var $modal = $("#small-modal");
                $modal.find("#small-modal-content").first().text('Do skal vælge en periode først');
                $modal.modal("show");
            }
        });

    }
}


