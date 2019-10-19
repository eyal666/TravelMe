function initWeatherWidget() {
  window.myWidgetParam ? window.myWidgetParam : window.myWidgetParam = [];
  window.myWidgetParam.push({ id: 12, cidtyid:'3617052', appid: '6f3c1e9d63a0e0cdbf13cac81950c7fa', units: 'metric', containerid: 'openweathermap-widget-12', });

  let script = document.createElement('script');
  script.async = true;
  script.charset = "utf-8";
  script.src = "//openweathermap.org/themes/openweathermap/assets/vendor/owm/js/weather-widget-generator.js";
  let s = document.getElementsByTagName('script')[0];
  s.parentNode.insertBefore(script, s);
}