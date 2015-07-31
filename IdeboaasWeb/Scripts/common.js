
if (window.active) {
  $("." + active).addClass("active");
}

var idebo = {
    showMessage : function(mes) {
        var $modal = $("#small-modal");
        $modal.find("#small-modal-content").first().text(mes);
        $modal.modal("show");
    }
};