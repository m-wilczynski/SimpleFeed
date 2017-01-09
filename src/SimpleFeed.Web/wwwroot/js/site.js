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