$(document).ready(function () {
    const defaultHelpMessageKey = $($('.helpinfodefault')[0]).attr('data-helpmessagekey');
    const messagesCache = {};
    RequestForHelpMessage(defaultHelpMessageKey);
    RegisterEventHaandlers();

    function RegisterEventHaandlers() {
        $('.helpinfo').each(function (index, item) {
            const helpMessageKey = $(item).attr('data-helpmessagekey');
            item.addEventListener('mouseenter', function () {
                RequestForHelpMessage(helpMessageKey);
            });
            item.addEventListener('mouseleave', function () {
                if (messagesCache['onfocus'] == null) { RequestForHelpMessage(defaultHelpMessageKey); }
                else { RequestForHelpMessage(messagesCache['onfocus']); }
            });
            $(item).find('input').each(function (index, inputElement) {
                inputElement.addEventListener('focus', function () {
                    CacheFocusedElement(helpMessageKey);
                    ApplyHelpMessage(messagesCache[helpMessageKey]);
                });
            });
            $(item).find('input').each(function (index, inputElement) {
                inputElement.addEventListener('blur', function () {
                    messagesCache['onfocus'] = null;
                    RequestForHelpMessage(defaultHelpMessageKey);
                })
            });
        });
    }

    function CacheFocusedElement(helpMessageKey) {
        messagesCache['onfocus'] = helpMessageKey;
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