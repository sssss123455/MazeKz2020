function del() {
  return  confirm('Удалить?');
}
set_onbeforeunload = function () {
	return true;
};

$(document).ready(function () {
	$(document).on('input', ':input', function () {
		window.onbeforeunload = set_onbeforeunload;
	});

	$('form').submit(function () {
		window.onbeforeunload = null;
	});
});