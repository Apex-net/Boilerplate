Boilerplate
===========

## Initial Requirements

0. Install [GitHub Desktop](https://desktop.github.com/) and set your default shell to "Git Bash" in options.

  > :information_source: You could install [Mintty](https://mintty.github.io/) (or any other terminal emulator) and [Git](https://git-scm.com/downloads) separately instead, but _we think_ the solution above is much easier. Although you may prefer **not** use GitHub Desktop, "Git Shell" (which is installed along with it) is *super* handy.

0. Install [NuGet command line utility](https://docs.nuget.org/consume/command-line-reference#user-content-installing)


## How to Create a New Project

```bash
# First off `cd` into wherever you want to create project folder
cd <somewhere>

# Set some variables...
PROJECT_NAME='foobar'
GH_USER='user'
GH_REPO='repo'

# 1. Create project directory
# 2. Download & extract the boilerplate
# 3. Setup files and contents using project name
# 4. Create empty git repository
# 5. Add files to source control
# 6. Add remote and push to GitHub
mkdir $PROJECT_NAME
curl -sL https://github.com/Apex-net/TryAzure/archive/master.tar.gz | tar -xzC $PROJECT_NAME --strip-components=1
cd $PROJECT_NAME
mv Boilerplate.sln "$PROJECT_NAME.sln"
git init && git commit --allow-empty -m"First commit."
git add . && git commit -m"Initial project structure."
git remote add origin "https://github.com/$GH_USER/$GH_REPO.git"
git push --set-upstream origin master
```

### Additional Steps & Associated Services

* Enable [branch protection](https://help.github.com/articles/configuring-protected-branches/) for `master` in GitHub with [required status checks](https://help.github.com/articles/enabling-required-status-checks/)
* Enable [AppVeyor](https://www.appveyor.com) Continuous Integration
* Enable [Continuous deployment with GitHub and Azure](https://github.com/blog/2056-automating-code-deployment-with-github-and-azure)


## Setup

```bash
script/setup
```
