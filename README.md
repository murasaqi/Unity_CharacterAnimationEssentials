# Character Animation Essentials

This repository is a collection of packages to easily control character animations with Unity's timeline and so on.

<img src="https://github.com/ProjectBLUE-000/Unity_CharacterAnimationEssentials/blob/master/Assets/Packages/CharacterAnimationEssentials/Thumbnails/thumbnail.gif" width="100%"/>

# How to use

## Facial Animation Timeline

1. Create Facial Preset

    Create facial preset assets for describe facial expressions.
    
    ![create](https://github.com/ProjectBLUE-000/Unity_CharacterAnimationEssentials/blob/master/Assets/Packages/CharacterAnimationEssentials/Thumbnails/CreateFacePreset.png)

2. Register corresponding blendshapes for facial expression

    Register a face type and corresponding blend shape values.

    ![blendshape](https://github.com/ProjectBLUE-000/Unity_CharacterAnimationEssentials/blob/master/Assets/Packages/CharacterAnimationEssentials/Thumbnails/BlendshapePreset.png)

3. Add Facial Timeline component to a gameobject.

    and set skinned mesh and add facial expression presets to the list. 

    ![facialtimelinecontrol](https://github.com/ProjectBLUE-000/Unity_CharacterAnimationEssentials/blob/master/Assets/Packages/CharacterAnimationEssentials/Thumbnails/FaceTimelineControl.png)

4. Create timeline for facial expression.

    create facial expression track and bind the Facial Timeline component. And create facial clip with selecting face type.

    ![facialtimeline](https://github.com/ProjectBLUE-000/Unity_CharacterAnimationEssentials/blob/master/Assets/Packages/CharacterAnimationEssentials/Thumbnails/FaceTimeline.png)

## Hand Animation Timeline

1. Create hand shape preset.

    Create hand shape preset assets for describe hand shape.

    ![createhandpreset](https://github.com/ProjectBLUE-000/Unity_CharacterAnimationEssentials/blob/master/Assets/Packages/CharacterAnimationEssentials/Thumbnails/CreateHandPreset.png)

2. Register corresponding finger rotation values.

    ![registerhandshape](https://github.com/ProjectBLUE-000/Unity_CharacterAnimationEssentials/blob/master/Assets/Packages/CharacterAnimationEssentials/Thumbnails/HandPreset.png)

3. Create hierarchy for hand animation timeline

    ![hierarchy](https://github.com/ProjectBLUE-000/Unity_CharacterAnimationEssentials/blob/master/Assets/Packages/CharacterAnimationEssentials/Thumbnails/HandHierarchy.png)

4. Register character's hand transforms

    Press detect button to find character's finger transforms.

    ![handtransformregister](https://github.com/ProjectBLUE-000/Unity_CharacterAnimationEssentials/blob/master/Assets/Packages/CharacterAnimationEssentials/Thumbnails/HandTransformRegister.png)

    Please edit `HandTransformDetection.cs` script for your convenience.
    
    ![handdetect](https://github.com/ProjectBLUE-000/Unity_CharacterAnimationEssentials/blob/master/Assets/Packages/CharacterAnimationEssentials/Thumbnails/HandDetectionScript.png)

5. Add each timeline hand control component to a gameobject.

    ![left](https://github.com/ProjectBLUE-000/Unity_CharacterAnimationEssentials/blob/master/Assets/Packages/CharacterAnimationEssentials/Thumbnails/LeftHandTimeline.png)

    ![right](https://github.com/ProjectBLUE-000/Unity_CharacterAnimationEssentials/blob/master/Assets/Packages/CharacterAnimationEssentials/Thumbnails/RightHandTimeline.png)

6. Create timeline

    Add hand timeline track and create some clips.

    ![handtimeline](https://github.com/ProjectBLUE-000/Unity_CharacterAnimationEssentials/blob/master/Assets/Packages/CharacterAnimationEssentials/Thumbnails/HandTimeline.png)


# さめるちゃんモデルライセンス

Design, Modeling and Rigging : さめ汰 (https://twitter.com/f_inari)

* 営利目的での使用は不可能です。
* 非営利目的で使用する場合も、下記連絡先までご連絡いただき、許諾を得たうえでのご使用をお願いいたします。
    * projectblue000@gmail.com 

# Code License
[MIT](LICENSE.md)