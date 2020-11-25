
class ChartRequest {
    constructor(sourceId, containerId, eventElement, loadChart) {
        const container = document.getElementById(containerId);

        (function RegisterHandlers() {
            eventElement.addEventListener('click', RequestChartItemData);
        })();

        function RequestChartItemData() {
            $.ajax({
                method: 'GET',
                url: '?handler=Concrete&chartId=' + document.getElementById(sourceId).value,
                contentType: 'application/json',
                success: LoadChart,
            });
        }

        function LoadChart(chart) {
            container.innerHTML = '';
            loadChart(containerId, chart.chartData);
        }
    }
}

export default ChartRequest