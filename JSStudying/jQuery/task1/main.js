$(function () {
  $('.burger-menu').click(function () {
    if ($('.burger-menu-opened').is(':visible')) {
      $('.burger-icon').html('&equiv;');
    } else {
      $('.burger-icon').html('&times;');
    }

    $('.burger-menu-opened').stop().slideToggle(222, function () {
      if ($(this).is(':visible')) {
        $(this).addClass('open');
      } else {
        $(this).removeClass('open');
      }
    });
  });
});
