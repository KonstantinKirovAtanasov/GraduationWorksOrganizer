let textArea = $('textarea.resize');
$(textArea).css('height', '150px');

$(document).ready(ResizeTextArea);

function ResizeTextArea() {
    $(textArea).on('input', function () {
        this.style.height = 'auto';
        this.style['min-height'] = '150px';
        this.style.height = this.scrollHeight + 'px';
    });