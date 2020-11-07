A Post Audit Tool made in Unity using ARFoundation and ARCore.

The Post Audit Tool allows users to visualise the suggestions provided by reports produced by the Core Audit Tool in a Augmented Reality setting, and then produce screenshots that can then be used outside of the Post Audit Tool.

Developed in Unity using ARFoundation and ARCore/ARKit.

CI Pipeline based on the unity3d-gitlab-ci project created by Gabriel Le Breton, which can be found at https://gitlab.com/gableroux/unity3d-gitlab-ci-example

[![pipeline status](https://gitlab.com/woofball/post-audit-tool/badges/master/pipeline.svg)](https://gitlab.com//post-audit-tool/commits/master)
[![coverage report](https://gitlab.com/woofball/post-audit-tool/badges/master/coverage.svg)](https://gitlab.com/woofball/post-audit-tool/-/commits/master)

# v0.0.4
New Features
 - Adds connectivity to Woofball API so that the Post Audit Tool can get Street Audits and their summary reports
 - Improves the User Interface to include the ability to view audits

## v0.0.3
New Features
 - Implements a complete overhaul of the user interface, including a sidebar with a set of options (Adding Props, Clearing Props, Viewing Options Menu, Taking a Screenshot, etc).
 - Adds a Prop Menu that is opened when a prop is selected
 - Adds ability to scale selected props
 - Adds ability to rotate selected props

## v0.0.2
New Features
 - Adds a Clear Button that removes all placed props from the environment

## v0.0.1

New Features
- Adds AR camera that visualises the users surroundings 
- Adds ability to select and place a variety of different props from a scroll menu, including lights, street signs, trees and benches
- Adds ability to enable/disable plane detection visualiser that displays where virtual props can be placed
- Adds button that allows screenshots of a conducted post audit to be taken
- Adds button that displays a list of suggested changes (Note: will be connected to the Core Audit Application soon, currently displays mock list of changes)
- Adds options menu that allows for contains button to enable/disable plane detection