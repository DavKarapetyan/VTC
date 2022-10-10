$(document).on('click', '.open-modal', function () {
	$('#dialogContent').load(this.href, function () {
		$('#dialogDiv').modal({
			backdrop: 'static',
			keyboard: true
		}, 'show');
	})
	return false;
});