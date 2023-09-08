/*
Template Name: Minible - Admin & Dashboard Template
Author: Themesbrand
Website: https://themesbrand.com/
Contact: themesbrand@gmail.com
File: Bootstrap Toasts Js
*/


//  Bootstrap Toast 
var toastTrigger = document.getElementById('liveToastBtn')
var toastLiveExample = document.getElementById('liveToast')
if (toastTrigger) {
    toastTrigger.addEventListener('click', function () {
        var toast = new bootstrap.Toast(toastLiveExample)

        toast.show()
    })
}


// Bordered Toast 

var toastTrigger2 = document.getElementById("borderedToast1Btn");
var toastLiveExample2 = document.getElementById("borderedToast1");
if (toastTrigger2) {
  toastTrigger2.addEventListener("click", function () {
    var toast = new bootstrap.Toast(toastLiveExample2);

    toast.show();
  });
}

var toastTrigger3 = document.getElementById("borderedToast2Btn");
var toastLiveExample3 = document.getElementById("borderedToast2");
if (toastTrigger3) {
  toastTrigger3.addEventListener("click", function () {
    var toast = new bootstrap.Toast(toastLiveExample3);

    toast.show();
  });
}

var toastTrigger4 = document.getElementById("borderedTost3Btn");
var toastLiveExample4 = document.getElementById("borderedTost3");
if (toastTrigger4) {
  toastTrigger4.addEventListener("click", function () {
    var toast = new bootstrap.Toast(toastLiveExample4);

    toast.show();
  });
}

var toastTrigger5 = document.getElementById("borderedToast4Btn");
var toastLiveExample5 = document.getElementById("borderedToast4");
if (toastTrigger5) {
  toastTrigger5.addEventListener("click", function () {
    var toast = new bootstrap.Toast(toastLiveExample5);

    toast.show();
  });
}



// placement toast

toastPlacement = document.getElementById("toastPlacement");
toastPlacement &&
  document
    .getElementById("selectToastPlacement")
    .addEventListener("change", function () {
      toastPlacement.dataset.originalClass ||
        (toastPlacement.dataset.originalClass = toastPlacement.className),
        (toastPlacement.className =
          toastPlacement.dataset.originalClass + " " + this.value);
    }),
  document.querySelectorAll(".bd-example .toast").forEach(function (a) {
    var b = new bootstrap.Toast(a, { autohide: !1 });
    b.show();
  });
