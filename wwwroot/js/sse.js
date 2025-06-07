window.sseInterop = {
    startBpmStream: function (dotnetHelper) {
        const source = new EventSource("http://itrackandi.watch:8082/1/live/bpm");

        source.addEventListener("message", (e) => {
            dotnetHelper.invokeMethodAsync("OnBpmReceived", e.data);
        }, false);

        source.onerror = function (e) {
            console.error("SSE error:", e);
            source.close();
        };

        // Optional: you could store `source` in window if you want to stop it later
        window._bpmSource = source;
    },
    stopBpmStream: function () {
        if (window._bpmSource) {
            window._bpmSource.close();
            window._bpmSource = null;
        }
    }
};
