$(function () {
  $("#readers-plus").click(function () {
    let num = parseInt($(this).attr("data-num")) + 1;

    $(this).attr("data-num", num);

    $('#num-of-readers').text('You are ' + num + ' reader now.');

    let link = $('.book .btn-read').attr('href');

    setTimeout(() => window.location.href = link, 1500);
  });
});