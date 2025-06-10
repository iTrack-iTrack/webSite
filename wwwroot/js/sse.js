window.sseInterop = {
    startBpmStream: function (dotnetHelper, ID, token) {
        if (window._bpmAbortController) {
            this.stopBpmStream();
        }
        console.log(token);

        const url = `http://itrackandi.watch:8082/${ID}/live`;

        window._bpmAbortController = new AbortController();

        fetch(url, {
            headers: {
                'Authorization': `Bearer ${token}`  
            },
            signal: window._bpmAbortController.signal  
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error(`HTTP error! Status: ${response.status}`);
                }

                const reader = response.body.getReader();
                const decoder = new TextDecoder();
                let buffer = '';  

                const processChunk = ({ done, value }) => {
                    if (done) {
                        console.log('Stream completed');
                        return;
                    }

                    buffer += decoder.decode(value, { stream: true });

                    const events = buffer.split('\n\n');

                    buffer = events.pop() || '';

                    events.forEach(event => {
                        const match = event.match(/^data:\s*(.+)$/);
                        if (match) {
                            try {
                                dotnetHelper.invokeMethodAsync("OnBpmReceived", match[1]);
                            } catch (e) {
                                console.error('JSON error:', e);
                            }
                        }
                    });

                    return reader.read().then(processChunk);
                };

                return reader.read().then(processChunk);
            })
            .catch(error => {
                if (error.name !== 'AbortError') {
                    console.error('SSE Error:', error);
                }
            });
    },

    stopBpmStream: function () {
        if (window._bpmAbortController) {
            window._bpmAbortController.abort(); 
            window._bpmAbortController = null;
        }
    }
};