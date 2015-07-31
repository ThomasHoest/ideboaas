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
        $(".booking-controls").show();
        $("#current-booking").first().text(start.format("DD-MM-YYYY") + " - " + end.format("DD-MM-YYYY"));
    }

    this.editBooking = function(event) {
        var $modal = $("#delete-modal");
        $modal.one("show.bs.modal", function(e) {
            $(this).find(".btn-ok").one("click", function () {
                $modal.modal("hide");
                page.verifyPassword().done(function() {
                    $.post("Booking/delete", { id: event.id }, function () {
                        $('#calendar-anchor').fullCalendar("removeEventSource", eventSource);
                        var ev = _.find(eventSource.events, function (e) { return e.id === event.id; });
                        if (ev) {
                            var index = eventSource.events.indexOf(ev);
                            if (index !== -1) {
                                eventSource.events.splice(index, 1);
                                $('#calendar-anchor').fullCalendar("addEventSource", eventSource);
                            }
                        }
                    });
                });
            });
            
        });
        $modal.modal("show");
    }

    this.guid = function(){
        function s4() {
            return Math.floor((1 + Math.random()) * 0x10000)
              .toString(16)
              .substring(1);
        }
        return s4() + s4() + '-' + s4() + '-' + s4() + '-' +
          s4() + '-' + s4() + s4() + s4();
    }

    this.initialize = function () {
        $('#calendar-anchor').fullCalendar({
            aspectRatio: 3,
            //events: bookings,
            selectable: true,
            eventClick:this.editBooking,
            select: this.selection
        });
        $('#calendar-anchor').fullCalendar("addEventSource", eventSource);
        $('#save-booking').on('click', function () {
            if (page._currentBooking.start) {
                var nameInput = $("#booking-name")[0];
                var name = nameInput.value;
                var type = $("#booking-type option:selected").text();
                page._currentBooking.title = name;
                page._currentBooking.color = type === "Blå" ? "blue" : "red";
                page._currentBooking.id = page.guid();
                page.verifyPassword().done(function() {
                    $.post("Booking/book", page._currentBooking, function () {
                        $('#calendar-anchor').fullCalendar("removeEventSource", eventSource);
                        eventSource.events.push(page._currentBooking);
                        $('#calendar-anchor').fullCalendar("addEventSource", eventSource);
                        nameInput.value = "";
                        $(".booking-controls").hide();
                    });
                });
            } else {
                var $modal = $("#small-modal");
                $modal.find("#small-modal-content").first().text('Do skal vælge en periode først');
                $modal.modal("show");
            }
        });

    }

    this.verifyPassword = function() {
        var deferred = $.Deferred();
        var $modal = $("#password-modal");
        $modal.one("show.bs.modal", function (e) {
            $(this).find(".btn-ok").one("click", function () {
                var inputPass = $("#password-input")[0];
                var pass = inputPass.value;
                $.post("Booking/password", { password: pass }, function (data) {
                    if (data === "True") {
                        deferred.resolve();
                    } else {
                        deferred.reject();
                        idebo.showMessage("Hmm, det var vist forkert?");
                    }
                });
                inputPass.value = "";
                $modal.modal("hide");
            });

        });
        $modal.modal("show");
        return deferred.promise();
    }
}


