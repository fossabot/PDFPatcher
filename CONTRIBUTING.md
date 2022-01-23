# Contribute to the PDFPatcher

Welcome to the PDFPatcher! This document is a guide on how to contribute to the PDFPatcher. Please leave a comment/suggestion if you find something incorrect or missing.

## Before the start

### Set up your development environment

See [README](https://github.com/wmjordan/PDFPatcher#%E8%BF%90%E8%A1%8C%E7%8E%AF%E5%A2%83).

## Contribute

Whether it's for typos, bug fixes, or important new features, we're always happy to accept your contributions. Please don't hesitate to discuss it on the [Github Issue](https://github.com/wmjordan/PDFPatcher/issues).

We take documentation very seriously, and we're happy to embrace improvements in these areas.

### GitHub Workflow

We use the `master` branch as the development branch.

Here is the workflow for contributors:

Fork to your personal repository.

Clone to local.

```git
git clone git@github.com:yourgithub/PDFPatcher.git
````

Create a new branch and work on it.

```git
git checkout -b your_branch
````

(It is not recommended to use `master` as `your_branch`.)

Keep the branch in sync with the upstream repository:

```git
git remote add upstream git@github.com:wmjordan/PDFPatcher.git
git remote update
git rebase upstream/master
````

Submit your changes (make sure your commit instructions are clear and complete).

```git
git commit -a
````

Clean up the commits, then push your commits to the forked repository.

```git
git push origin your_branch
````

Create a pull request merge request.

Subsequent modifications should generally be forced to push to the forked repository:

```git
git push origin your_branch -f
````

Please make sure that the PR corresponds to the corresponding Issue. See [Linking Pull Requests to Issues - GitHub Docs](https://docs.github.com/cn/issues/tracking-your-work-with-issues/linking-a-pull-request-to-an-issue) .

After the PR is created, members of the community will help with the review. After the review is passed, the PR will be merged into the main repository and the corresponding issue will be closed.

### Open Issue/PR

We use Issues and Pull Requests as trackers:

- [GitHub Issues](https://github.com/wmjordan/PDFPatcher/issues)
- [Pull Requests](https://github.com/wmjordan/PDFPatcher/pulls)

If you find a new bug, want a new feature, or suggest something new, you can [create an Issue](https://github.com/wmjordan/PDFPatcher/issues/new/choose) on GitHub, follow the Issue template operate according to the guidelines in .

If you find a typo in the documentation, or if you see a small optimization in the code, you can submit a PR without creating an issue.

If you want to contribute, please create a new PR first. If your PR contains major changes, please write a detailed description of its design and use.

> **Note**
>
> A single PR should not be too large. If breaking changes are required, it's best to split the changes into a few PRs.

### PR review

All PRs should be well reviewed. Some principles:

- Ease of use. Changes should not negatively affect the ease of use of the software.

- 3rd party code is kept as it is. The code outside the PDFPatcher namespace is a third-party code, and should not be modified unless necessary.

### PR merge

After the PR is Approve, it will be merged by the Committer. During the merge, the Committer can modify the commit description.
Rebase and merge are generally used when merging. For large multi-person PRs, use Merge to merge, and commit via Rebase revisions before merging.
