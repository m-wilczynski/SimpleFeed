function wireSubmitVote(entryId, isPositive) {

    var prefix = isPositive ? "upvote-" : "downvote-";

    $("#" + prefix + entryId).submit(function (e) {
            $.ajax({
                async: true,
                url: this.action,
                type: this.method,
                dataType: "json",
                data: $(this).serialize(),
                success: function (result) {
                    if (!result.success) return;

                    var votesEl = $("#votescount-" + entryId + " span");
                    votesEl.text(result.newVoteBalance);
                }
            });
        e.preventDefault();
    });
}

function showLoader(loaderText) {

    var loader = document.getElementById('loader');
    var animationWrapper = document.getElementById('loader-animation-wrapper');
    if (!loader || !animationWrapper) throw 'One of loader elements not found!';

    animationWrapper.style.marginTop = (window.innerHeight / 2 - 110) + "px";
    loader.style.display = 'initial';
    loader.style.opacity = 1;
    loader.focus();

    animateWave(loaderText);
}