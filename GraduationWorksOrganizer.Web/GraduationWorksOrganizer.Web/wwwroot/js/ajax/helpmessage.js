$(document).ready(function () {
    const defaultHelpMessageKey = $($('.helpinfodefault')[0]).attr('data-helpmessagekey');
    const messagesCache = {};
    RequestForHelpMessage(defaultHelpMessageKey);
    RegisterEventHaandlers();

    function RegisterEventHaandlers() {
        let items = $('.helpinfo');
        for (let i = 0; i < items.length; i++) {
            items[i].addEventListener('mouseenter', function () {
                const helpMessageKey = $(items[i]).attr('data-helpmessagekey');
                RequestForHelpMessage(helpMessageKey);
            });
            items[i].addEventListener('mouseleave', function () {
                RequestForHelpMessage(defaultHelpMessageKey);
            });
        }
    }

    function RequestForHelpMessage(helpMessageKey) {
        if (helpMessageKey in messagesCache) {
            ApplyHelpMessage(messagesCache[helpMessageKey]);
            console.log('cachedValueProvided');
        }
        else {
            const url = 'https://localhost:44306/api/HelpMessages';
            $.ajax({
                url: url + '/' + helpMessageKey,
                success: ApplyHelpMessage,
                error: function (error) { console.log(error) }
            });
        }
    }

    function ApplyHelpMessage(result) {
        if (!(result.key in messagesCache)) {
            messagesCache[result.key] = result;
            console.log('valueCached');
        }
        $('.helptitle')[0].textContent = result.title;
        $('.helpcontent')[0].textContent = result.content;
    }
});