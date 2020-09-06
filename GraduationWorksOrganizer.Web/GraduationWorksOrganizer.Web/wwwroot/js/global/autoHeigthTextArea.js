let textArea = $('textarea.resize');

$(document).ready(ResizeTextArea);

function ResizeTextArea() {
    $(textArea).each((index, item) => {
        RegisrerResizeHandler(item);
    });
}

function RegisrerResizeHandler(element) {
    $(element).on('input', function () {
        this.style.height = 'auto';
        this.style.height = this.scrollHeight + 5 + 'px';
    })
}
