flowplayer("player", "flash/flowplayer-3.2.7.swf", {
	screen:	{
		bottom: 0
	},

	plugins: {
		controls: {
			url: 'flash/flowplayer.controls-3.2.5.swf',
			
			backgroundColor: "#111111",
			backgroundGradient: "none",
			sliderColor: '#FFFFFF',
			sliderBorder: '1.5px solid rgba(160,160,160,0.7)',
			volumeSliderColor: '#FFFFFF',
			volumeBorder: '1.5px solid rgba(160,160,160,0.7)',

			timeColor: '#ffffff',
			durationColor: '#535353',

			tooltipColor: 'rgba(255, 255, 255, 0.7)',
			tooltipTextColor: '#000000'
		}
	},
	clip: {
		autoPlay: true,
		url: data['Attachment']['OriginalPath']
	}
});

alert('sadgsaddsg');