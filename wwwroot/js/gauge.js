window.createGauge = (canvasId, value) => {
    const ctx = document.getElementById(canvasId).getContext('2d');

    const data = {
        datasets: [{
            data: [value, 100 - value],
            backgroundColor: ['#4caf50', '#e0e0e0'],
            borderWidth: 0,
            cutout: '80%'
        }]
    };

    const centerTextPlugin = {
        id: 'centerText',
        afterDraw(chart) {
            const { ctx, chartArea: { width, height } } = chart;
            ctx.save();
            ctx.font = '30px Arial';
            ctx.fillStyle = '#000';
            ctx.textAlign = 'center';
            ctx.textBaseline = 'middle';
            ctx.fillText(value + '%', width / 2, height * 0.75);
            ctx.restore();
        }
    };

    const config = {
        type: 'doughnut',
        data: data,
        options: {
            rotation: -180 * (Math.PI / 180),
            circumference: 180 * (Math.PI / 180),
            cutout: '80%',
            responsive: false,
            plugins: {
                tooltip: { enabled: false },
                legend: { display: false }
            }
        },
        plugins: [centerTextPlugin]
    };

    // Store chart instance so you can update/destroy later if needed
    if (window.gaugeChart) {
        window.gaugeChart.destroy();
    }
    window.gaugeChart = new Chart(ctx, config);
}

window.updateGauge = (value) => {
    if (window.gaugeChart) {
        // Update the data values
        window.gaugeChart.data.datasets[0].data = [value, 100 - value];
        
        // Update the center text (via plugin)
        window.gaugeChart.options.plugins.centerText = {
            id: 'centerText',
            afterDraw(chart) {
                const { ctx, chartArea: { width, height } } = chart;
                ctx.save();
                ctx.font = '30px Arial';
                ctx.fillStyle = '#000';
                ctx.textAlign = 'center';
                ctx.textBaseline = 'middle';
                ctx.fillText(value + '%', width / 2, height * 0.75);
                ctx.restore();
            }
        };
        
        // Trigger update
        window.gaugeChart.update();
    }
}