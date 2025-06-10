window.sseInterop = {
    startBpmStream: function (dotnetHelper, ID) {
        const source = new EventSource(`http://itrackandi.watch:8082/${ID}/live`);

        source.addEventListener("message", (e) => {
            dotnetHelper.invokeMethodAsync("OnBpmReceived", e.data);
        }, false);

        source.onerror = function (e) {
            console.error("SSE error:", e);
            source.close();
        };

        window._bpmSource = source;
    },
    stopBpmStream: function () {
        if (window._bpmSource) {
            window._bpmSource.close();
            window._bpmSource = null;
        }
    }
};
