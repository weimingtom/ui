﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace UIEditor.BoloScript
{
	public partial class TextControl : UserControl
	{
		public FileTabItem m_parent;
		public OpenedFile m_openedFile;
		public string m_lastText;
		public bool m_isCheckChange;
		static public Dictionary<SolidColorBrush, List<string>> s_mapKeyWordsGroup;
		public Public.EventLock m_eventLock;

		public TextControl(FileTabItem parent, OpenedFile fileDef)
		{
			m_eventLock = new Public.EventLock();
			if (s_mapKeyWordsGroup == null)
			{
				s_mapKeyWordsGroup = new Dictionary<SolidColorBrush, List<string>>
				{
					{
						new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0x4E, 0xC9, 0xB0)),
						new List<string>
						{
						}
					},
					{
						#region 关键字
						new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0x56, 0x9C, 0xD6)),
						new List<string>
						{
							"String ", "int ", "bool ", "double ", "float ", "long ", "short ",
							"if", "else", "do", "while", "for", "switch", "case", "default",
							"break", "continue", "goto",
							"struct", "class", "function", "sizeof", "static", "call"
						}
						#endregion
					},
					{
						//Netbeans中查找引用后，在VS中正则替换“.*registerFunc\(id,[ ]*"([0-9a-z_]*)".*”为“"$1(",”。然后，“\n([a-z]+)”变为“\n//$1”。
						new SolidColorBrush(System.Windows.Media.Color.FromArgb(0xFF, 0xFF, 0x80, 0x00)),
						new List<string>
						{
							#region 函数名
							//DsBoloUI
							//BoloScriptUtil.cpp
							"parseInt(",
							"parseIntBackward(",
							"replaceInt(",
							"replaceIntBackward(",
							"replaceString(",
							"replaceWString(",
							"lowcase(",
							"checkFullwidthChar(",
							"convertFullwidthChar(",
							"getUrlArg(",
							//BoloUISceneLib.cpp
							"getName(",
							"clear(",
							"get(",
							"set(",
							"getAuction(",
							"setAuction(",
							"clearAuction(",
							"getPointerX(",
							"getPointerY(",
							"getPointerId(",
							"getCurSceneName(",
							"setScenePosition(",
							"getScreenW(",
							"getScreenH(",
							"loadUIData(",
							"getAfkTime(",
							"getAfkTimeSeconds(",
							"onSceneEvent(",
							"setMaskUiDrawMode(",
							"enableCheckUiCanmoveRole(",
							"rename(",
							"getNameWithID(",
							"setNameWithID(",
							"setSceneVisible(",
							"setSceneVisibleForce(",
							"getSceneVisible(",
							"setVisible(",
							"setVisible_alpha(",
							"setVisibleWithID(",
							"setVisibleWithID_alpha(",
							"setVisibleWithID_checkCondition(",
							"setParentVisibleWithID(",
							"getVisible(",
							"getVisibleWithID(",
							"getOnDrawWithID(",
							"getVisibleWithID_conditionSet(",
							"getSetVisible(",
							"getSetVisibleWithID(",
							"setFocus(",
							"setFocusWithID(",
							"getFocus(",
							"getFocusWithID(",
							"setCanFocus(",
							"setCanFocusWithID(",
							"getCanFocus(",
							"getCanFocusWithID(",
							"setEnable(",
							"setEnableWithID(",
							"setEnableWithID_checkCondition(",
							"getEnable(",
							"getEnableWithID(",
							"getEnableWithID_conditionSet(",
							"getShowMovied(",
							"getShowMoviedWithID(",
							"getText(",
							"getTextWithID(",
							"setText(",
							"setTextWithID(",
							"setTextJustWithID(",
							"getSkin(",
							"getSkinWithID(",
							"setSkin(",
							"setSkinWithID(",
							"setPosition(",
							"setPositionWithID(",
							"setPositionWithScreenPosition(",
							"setScreenPosition(",
							"setScreenPositionWithID(",
							"getX(",
							"getY(",
							"getXWithID(",
							"getYWithID(",
							"getx(",
							"gety(",
							"getxWithID(",
							"getyWithID(",
							"getDx(",
							"getDy(",
							"getDxWithID(",
							"getDyWithID(",
							"getInitDx(",
							"getInitDy(",
							"getInitDxWithID(",
							"getInitDyWithID(",
							"getDrawX(",
							"getDrawY(",
							"getDrawXWithID(",
							"getDrawYWithID(",
							"getInitDrawX(",
							"getInitDrawY(",
							"getInitDrawXWithID(",
							"getInitDrawYWithID(",
							"getID(",
							"setCountdownPresetTimestringWithID(",
							"copyAndAddTo(",
							"copyAndAddTo_alpha(",
							"copyAndAddToWithID(",
							"copyAndAddToBrotherWithID(",
							"copyAndAddToWithID_alpha(",
							"copyAndInsertToWithID(",
							"copyAndAddToAnotherScene(",
							"setHeight(",
							"setWidth(",
							"getHeight(",
							"getWidth(",
							"getHeightWithID(",
							"getWidthWithID(",
							"setScale(",
							"setScaleWithID(",
							"setUIScript(",
							"setControlScript(",
							"setControlScriptWithID(",
							"runControlScript(",
							"runControlScriptWithID(",
							"showMessage(",
							"onEvent_onClick(",
							"onEvent_onClick_WithID(",
							"onEvent_onClick_WithID_curScene(",
							"onEvent(",
							"onEvent_WithID(",
							"getParentName(",
							"getParentIDWithID(",
							"getParentNameWithID(",
							"setApperance(",
							"setApperanceWithID(",
							"setCurApperanceScale(",
							"setCurSkinImgGrayLevelWithID(",
							"setTextAlphaWithID(",
							"setDraggedPanelWithID(",
							"isExistControl(",
							"isExistControlWithID(",
							"getControlState(",
							"getControlStateWithID(",
							"setControlState(",
							"setControlStateWithID(",
							"setControlDataWithID(",
							"getControlDataWithID(",
							"addControlDataWithID(",
							"removeControlDataWithID(",
							"moveScrollTopWithID(",
							"moveScrollBottomWithID(",
							"enableZoomAnimation(",
							"enableZoomAnimationWithID(",
							"setZoomAnimationAnchorWithID(",
							"setAngle(",
							"setAllSkinAngleWithIDAndApType(",
							"setAllSkinAngleWithIDAndApTypeAndApId(",
							"setStopFrameIndex(",
							"getStopFrameIndex(",
							"setEnableClipArea(",
							"enableRotateAnimationWithID(",
							"enableMoveAnimationWithID(",
							"enableZoomAnimationListWithID(",
							"clearAnimationEffectWithID(",
							"getAnimationActiveWithID(",
							"getZoomAnimationScalexWithID(",
							"setRememberScrollPos(",
							"setRememberScrollPosWithID(",
							"setAnchor(",
							"setAnchorWithID(",
							"setAnchorSelf(",
							"setAnchorSelfWithID(",
							"getExpectVisibleWithID(",
							"setColorWithID(",
							"updateSkinWithXml(",
							"getUiNeedResourceList(",
							"loadImportXml(",
							"removeImportXml(",
							"removeUiImportXml(",
							"removeImportXmlWithId(",
							"removeAllImportXml(",
							"setControlCsvDataWithID(",
							"getControlCsvDataWithID(",
							"createBoloUISkin(",
							"moveControlScrollLen(",
							"moveControlScrollLenWithID(",
							"getTextLenWithID(",
							"clearAddControl(",
							"clearAddControlWithID(",
							"clearAddControlWithBrotherID(",
							"getControlIndex(",
							"setControlIndex(",
							"getControlIndexWithID(",
							"getControlIDWithIndex(",
							"getControlIDWithIndexById(",
							"getVControlIDWithIndex(",
							"getVControlIDWithIndexById(",
							"getAddControlIDWithIndex(",
							"getAddControlIDWithIndexByID(",
							"getCheckOnID(",
							"getCheckOnIDWithID(",
							"removeControlWithID(",
							"removeControl(",
							"getControlsSize(",
							"getVControlsSize(",
							"getAddControlsSize(",
							"getVControlsSizeWithID(",
							"getControlsSizeWithID(",
							"getAddControlsSizeWithID(",
							"getRadioOnselect(",
							"getRadioOnselectWithID(",
							"setControlScrollDecaySpeed(",
							"setControlScrollDecaySpeedWithID(",
							"setSkinGrayLevelWithID(",
							"getControlIDByWindowIDWithIndex(",
							"getVControlIDByWindowIDWithIndex(",
							"getControlTypeWithID(",
							"checkAllUIExceptName(",
							"checkAllUIExceptNamelist(",
							"setCurrentValue(",
							"setCurrentValueWithID(",
							"setChangeSpeedWithID(",
							"setChangeRateWithID(",
							"setShowValueWithID(",
							"getCurrentValueWithID(",
							"getCurrentValue(",
							"getShowValue(",
							"getShowValueWithID(",
							"setShowValue(",
							"setChangeSpeed(",
							"getChangeSpeed(",
							"setChangeRate(",
							"getChangeRate(",
							"getProgressMax(",
							"getProgressMin(",
							"setProgressMax(",
							"setProgressMin(",
							"setProgressDecaySpeed(",
							"setProgressDecay(",
							"getProgressDecaySpeed(",
							"getProgressDecay(",
							"setProgressPreGrowth(",
							"getProgressPreGrowth(",
							"getProgressBufferValue(",
							"setProgressBufferPercent(",
							"setProgressDecayAdd(",
							"checkValueStep(",
							"checkValueStepWithID(",
							"getTabSelectIndex(",
							"getTabSelectIndexWithID(",
							"getTabSelectIndexWithID_atControls(",
							"setTabSelectIndex(",
							"setTabSelectIndexNoEvent(",
							"setTabSelectIndexWithID(",
							"setTabSelectIndexWithID_atControls(",
							"setTabSelectIndexWithIDNoEvent(",
							"getTabControlIndexText(",
							"getTabVcontrolSize(",
							"enTabBlink(",
							"enTabBlinkWithID(",
							"setTabBlink(",
							"setTabBlinkWithID(",
							"getTabSelectName(",
							"getTabSelectID(",
							"getTabInfo(",
							"getTabInfoWithID(",
							"setTabPack(",
							"setTabPackWithID(",
							"getTabPack(",
							"getTabPackWithID(",
							"getTabSelectedWithID(",
							"isSelect(",
							"isSelectWithID(",
							"getRadioSelectWithID(",
							"setRadioSelect(",
							"setRadioSelectWithID(",
							"setRadioOnSelect(",
							"setRadioOnSelectWithID(",
							"setRadioSelectWithID_onEvent(",
							"getCheckSelect(",
							"getCheckSelectWithID(",
							"setCheckSelect(",
							"setCheckSelectWithID(",
							"getHandScale(",
							"getDraggedX(",
							"getDraggedY(",
							"getDraggedXlen(",
							"getDraggedYlen(",
							"getPanelDdx(",
							"getPanelDdy(",
							"setPanelControlAtMiddle(",
							"getSkillButtonCDWithID(",
							"setSkillButtonCDWithID(",
							"getSkillButtonLeftCDWithID(",
							"setSkillButtonLeftCDWithID(",
							"setSkillButtonStartCDWithID(",
							"getSkillButtonColdDownWithID(",
							"cancleCD(",
							"cancleCDWithID(",
							"setCD(",
							"startCD(",
							"getListSelectIndex(",
							"getListSelectIndexWithID(",
							"setListSelectIndex(",
							"getListSelectID(",
							"getListSelectedID(",
							"getListSelectedIDWithID(",
							"getListVcontrolSize(",
							"getListVcontrolSizeWithID(",
							"getListAddcontrolSizeWithID(",
							"getListCheckOnID(",
							"getListVControlIDWithIndex(",
							"getListVControlIDWithIndexWithID(",
							"getListControlIDWithIDWithIndex(",
							"getListAddControlIDWithIndex(",
							"setListVscrollBottom(",
							"setListVscrollBottomForce(",
							"setListVscrollTop(",
							"getListControlsMax(",
							"setListControlAtMiddle(",
							"setListSelectBaseIDWithID(",
							"setRichVscrollBottom(",
							"setRichVscrollBottomForce(",
							"setRichVscrollTop(",
							"setRichConvertFace(",
							"setRichConvertFaceWithID(",
							"setRichReadonly(",
							"setRichTips(",
							"setRichTipsWithID(",
							"getRichTipsWithID(",
							"setRichInputFocus(",
							"getRichInputFocus(",
							"setRichShowInput(",
							"getRichClickAreas(",
							"getRichClickAreasWithID(",
							"setRichBeforeSkins(",
							"setRichBeforeSkinsWithID(",
							"setRichFocus(",
							"setRichFocusWithID(",
							"getDraggedPanel_srcName(",
							"getDraggedPanel_srcID(",
							"setDraggedPanelDraggedCheckOri(",
							"setDraggedPanelDraggedCheckOriWithID(",
							"getIsCopyExist(",
							"setCopyVisibleWithID(",
							"getCopyDrawXWithID(",
							"getCopyDrawYWithID(",
							"enButtonBlink(",
							"enButtonBlinkWithID(",
							"isButtonBlinkWithID(",
							"enButtonCountClickWithID(",
							"setButtonBlink(",
							"setButtonBlinkWithID(",
							"setButtonBlinkTimeWithID(",
							"getButtonBlinkTimeWithID(",
							"setButtonBlinkTextWithID(",
							"getButtonBlinkTextWithID(",
							"getButtonCountClickWithID(",
							"setButtonCountClickWithID(",
							"setCountdownTime(",
							"setCountdownTimeWithID(",
							"getCountdownTimeWithID(",
							"setCountdownStart(",
							"setCountdownStartWithID(",
							"setCountdownType(",
							"setCountdownTypeWithID(",
							"setCountdownTimestring(",
							"setCountdownRateWithID(",
							"setTurntableResult(",
							"setTurntableResultWithID(",
							"setTurntableRun(",
							"setTurntableRunWithID(",
							"getTurntableOnrunning(",
							"setVirtualPadBlinkWithID(",
							"setVirtualPadType(",
							"getVirtualPadType(",
							"setLabelScrollcountType(",
							"setLabelScrollTime(",
							"setLabelDefaultMsgTime(",
							"setLabelTextscrollBeginX(",
							"setLabelScrollTimeMax(",
							"setLabelNextUiEvent(",
							"setPagepanelTurnEnable(",
							"setPagepanelTurnEnableWithID(",
							"setPagepanelStopIndex(",
							"setPagepanelStopIndexWithID(",
							"setPagepanelStopIDWithID(",
							"getPagepanelStopIndex(",
							"getPagepanelStopIndexWithID(",
							"addItem(",
							"getItem(",
							"setOnkeySelectWithID(",
							"setOnkeySelectWithName(",
							"getKeyCurnodeExist(",
							//BoloXML.cpp
							"loadFile(",
							"loadFileWithResName(",
							"clear(",
							"next(",
							"getName(",
							"getText(",
							"getAttributeValue(",
							"endOfFile(",
							"getDepth(",
							"isTagStart(",
							"isTextStart(",
							"endOfFile(",
							"nextTag(",
							"nextStartTagName(",
							"readNextTagWithName(",
							//MOBASprite
							//SpriteScriptManager.cpp
							"roleUseSkillWithIndex(",
							"roleCancelSkillWithIndex(",
							"roleMoveToPosition(",
							"getRoleSkillIsDurationSkill(",
							"getRoleSkillIsInstantSkill(",
							"roleShowSkillRange(",
							"createSprite(",
							"getModelHeight(",
							"setSpriteScale(",
							"setSpriteMaterial(",
							"setSpriteMaterialHeightLight(",
							"deleteSprite(",
							"initSpriteBloodBar(",
							"getMonsterBloodType(",
							"createParticleAtPos(",
							"createParticleAtPosWithLoop(",
							"createParticleAtPosWithLoopAndCreateInfo(",
							"createParticleAtPosWithLoopAndCreatorID(",
							"createParticleWithSprite(",
							"createParticleWithSpriteBind(",
							"createParticleWithSpriteBindAndLoop(",
							"createParticleWithSpriteBindAndLoopAndDeathType(",
							"createParticleWithSpriteBindAndLastTime(",
							"isParticlePlaying(",
							"setParticleRotateEuler(",
							"setParticleText(",
							"setParticleStringBoardFont(",
							"removeParticle(",
							"stopParticle(",
							"playParticle(",
							"removeAllBindParticle(",
							"setAllBindParticleVisible(",
							"removeBindParticleWithName(",
							"setParticleVisible(",
							"setParticleScale(",
							"setPlaneMeshParticleScale(",
							"setSpritePosition(",
							"hideModelGroupWithIndex(",
							"setModelGroupColorWithIndex(",
							"getSpritePosition(",
							"getSpriteInitTime(",
							"setSpriteState(",
							"clearSpriteState(",
							"setSpriteAngle(",
							"getSpriteAngle(",
							"getSpriteTurnSpeed(",
							"setSpriteTurnSpeed(",
							"enableSpriteTowerActive(",
							"isCheckTowerAttackRingType(",
							"setTurnMaxTime(",
							"setBrokenHp(",
							"getSpriteHeight(",
							"getSpriteModelName(",
							"getSpriteIdsWithPrototype(",
							"getPrototypeWithID(",
							"getSpriteState(",
							"isSpriteDeath(",
							"isSpriteMoving(",
							"getSpriteVisible(",
							"setSpriteVisible(",
							"setSpriteHeroBornDelay(",
							"setSpriteHeroBornInterval(",
							"updateSpriteHeroBornDelay(",
							"getSpriteIsInScreen(",
							"clearAllSprite(",
							"setCameraLookAtToRole(",
							"setCameraLookAtToSprite(",
							"setCameraLookAtToPos(",
							"setCameraLookAtToMiniMapPos(",
							"enableCameraFollowToRole(",
							"setCameraFollowToRole(",
							"setCameraFollowToSprite(",
							"getCameraFollowToSprite(",
							"setCameraFollowPosOffset(",
							"getCameraBornPos(",
							"setCameraLightEnable(",
							"getRoleId(",
							"getSpriteCampIndex(",
							"getSpriteName(",
							"getRoleCampIndex(",
							"getHeroSkillLen(",
							"reduceSkillCd(",
							"getHeroSkillWithIndex(",
							"getHeroAttributeLen(",
							"getHeroAttributeWithIndex(",
							"getHeroTalentLen(",
							"getHeroTalentWithIndex(",
							"getHeroLevelWithId(",
							"getHeroIsBelongRoleWithID(",
							"getBelongRoleWithID(",
							"getHeroStarWithID(",
							"getCareerIndexWithID(",
							"getSpriteHp(",
							"getRoleHpMp(",
							"enableFreezeHeight(",
							"setServerTempModelAnimationMap(",
							"checkSpriteExist(",
							"setAction(",
							"setActionList(",
							"transMapPosToScreenPos(",
							"transScreenPosToMapPosInCameraHeight(",
							"transScreenPosToMapPosWithPara(",
							"isEnemy(",
							"isHero(",
							"isTower(",
							"isEliteMonster(",
							"isNormalMonster(",
							"isNpc(",
							"isRole(",
							"setFocusHero(",
							"addSpriteSign(",
							"setSpriteBindEntity(",
							"addSpriteInf(",
							"addProgressPanel(",
							"setSpriteUIInitScaleParam(",
							"setSpriteSmallBloodBar(",
							"addGainPanel(",
							"addBattleSpriteFunc(",
							"setScreendis2mapdisRate(",
							"enableMergeStatic(",
							"zoomCamera(",
							"changeCameraTransform(",
							"getCameraWorldPos(",
							"setCameraWorldPos(",
							"rotateCamera(",
							"rotateCameraEuler(",
							"rotateCameraAxis(",
							"rotateCameraAxisTmp(",
							"pitchCamera(",
							"turnCamera(",
							"pitchCameraAxis(",
							"yawCameraAxis(",
							"rollCameraAxis(",
							"setCameraFov(",
							"setCameraExposure(",
							"getCameraExposure(",
							"setWhiteBalance(",
							"getWhiteBalance(",
							"setCameraDistanceLimit(",
							"setCameraRotateLimit(",
							"setCameraDistance(",
							"getCameraDistance(",
							"getCameraEyePosition(",
							"getCameraViewPosition(",
							"setCameraPosition(",
							"setCameraEyePosition(",
							"setCameraAngle(",
							"setMainCameraVisible(",
							"setSpriteControlIsLock(",
							"setCameraCanRespondMultipoint(",
							"setSamplingWithWorld(",
							"resetCamera(",
							"moveCamera(",
							"getMapArea(",
							"getMapRangeAndStep(",
							"checkCameraAreaLimit(",
							"getCameraAxisRotateEuler(",
							"getCameraAxisRotate(",
							"getCameraRotateEuler(",
							"setCameraAxisRotationEuler(",
							"setCameraEyeRotationEuler(",
							"setCameraAxisPos(",
							"getCameraAxisRotation(",
							"getCameraRotation(",
							"setCameraTargetSprite(",
							"getCameraYAngle(",
							"setCameraFarClip(",
							"setCameraNearClip(",
							"setResetCheckTime(",
							"setResetToRole(",
							"setCameraFollowType(",
							"getCameraFollowType(",
							"setEnableLightShadow(",
							"getEnableLightShadow(",
							"enablePrefabMeshShadow(",
							"setCameraMinNearClip(",
							"setCameraNearClipParam(",
							"setCameraShadowMapRange(",
							"getCameraShadowMapRange(",
							"setMiniMapVisible(",
							"setMiniMapPosition(",
							"setMiniMapSize(",
							"playReplay(",
							"pauseReplay(",
							"continueReplay(",
							"switchReplayPlay(",
							"stopReplay(",
							"destoryReplay(",
							"isReplayEnd(",
							"getReplayRate(",
							"getCurReplayVer(",
							"setReplayRate(",
							"setCurCampIndex(",
							"getCurCampIndex(",
							"setWarFogEnable(",
							"getWarFogEnable(",
							"setWarFogColor(",
							"setMapVisibleCampList(",
							"getMapVisibleCampList(",
							"getTimeStable(",
							"getTime(",
							"getDeltaTime(",
							"getBaseCampRoleId(",
							"getBaseCampRoleName(",
							"getBaseCampCupCount(",
							"getBaseCampRoleLv(",
							"getBaseCampRoleExp(",
							"getBaseCampRoleHeadSkin(",
							"initSound(",
							"getSoundListenerPos(",
							"setSoundListenerPos(",
							"setBGMVolume(",
							"playSound(",
							"playSoundWithVolume(",
							"playBigSound(",
							"stopSound(",
							"stopAllSound(",
							"stopBigSound(",
							"playSoundEffect(",
							"playSpriteSoundEffect(",
							"stopSoundEffect(",
							"setMusicEnable(",
							"setMusicEffectEnable(",
							"setEffectVolume(",
							"getEffectVolume(",
							"stopBigSound_unLoad(",
							"getSoundLenMs(",
							"setVoiceVolume(",
							"getVoiceVolume(",
							"setBackgroundSoundVolume(",
							"getBackgroundSoundVolume(",
							"setZoomScale(",
							"setMapEntityVisible(",
							"yawMapEntity(",
							"setMapEntityLock(",
							"setMapEntityGray(",
							"setMapEntityLightVisible(",
							"setMapEntityPlay(",
							"setSkyPosition(",
							"getSkyPosition(",
							"getMapEntityIsPlaying(",
							"playEnterHomeAnimation(",
							"setFog(",
							"getMeshDateAnimationPlayTimes(",
							"getQuat(",
							"getQuatToTarget(",
							"clickScreenCallBack(",
							"stopRoleMove(",
							"clearBeginInputEvent(",
							"setCameraBornDis(",
							"setSignZoomInitValue(",
							"setCameraInitZoomDis(",
							"setCameraInitZoomRange(",
							"setSpriteControlIsCheckLimit(",
							"setIsCanDrag(",
							"setIsLockDrag(",
							"setIsLockClick(",
							"setIsLockScroll(",
							"setTarget(",
							"getTargetId(",
							"setSkillCreateStyle(",
							"shakeScreen(",
							"clearShake(",
							"getFaceAngle(",
							//SpeedSharkBenchmark
							//GLMain.cpp
							"testParticle(",
							"testScene(",
							"test2d(",
							"testMathlib(",
							"testStlib(",
							"testSum(",
							"backToHome(",
							"testMathShow(",
							"testStdShow(",
							"testTwoDShow(",
							"saveScore(",
							"sceneView(",
							"showConnList(",
							"connRemoteNode(",
							"deleteRemoteNode(",
							"editRemoteNode(",
							"addIPInfo(",
							"addConfirm(",
							"cancel(",
							"editConfirm(",
							"closeConnect(",
							"setPath(",
							"deletePath(",
							"moveUp(",
							"moveDown(",
							"addPath(",
							"editPath(",
							"clearPath(",
							"cancelDownload(",
							"viewScore(",
							"showScoreDetails(",
							"deleteScoreDetails(",
							"clearParticles(",
							"setCount(",
							"saveCount(",
							"backDefault(",
							"floatDrag(",
							"enableShadow(",
							"enableLight(",
							"setSpeed(",
							"sceneShow(",
							"renderLevelSet(",
							"selectQuality(",
							//SpeedSharkFramework
							//ResDownloadLib.cpp
							"reset(",
							"getPolicy(",
							"runHelper(",
							"perRunDownload(",
							"getDownloadSize(",
							"runDownload(",
							"getShowString(",
							"getNetSpeed(",
							"getCurDownFileName(",
							"getCurDownFileProg(",
							"getDownloadProg(",
							#endregion
						}
					},
					
					{
						#region 运算符
						new SolidColorBrush(Colors.White),
						new List<string>
						{
							// ([!@#$%^&*-=+,./;'\<>?:"|\(\)\[\]{}])       "$1", 
							"+", "-", "*", "/", "=", "%",
							"&", "|", "!", "^",
							";", ",", ".", ":", "?", "'", "\"",
							"<", ">", "(", ")", "[", "]", "{", "}",
							"\\",
							"@", "#", "$", 
						}
						#endregion
					},
				};
			}
			m_isCheckChange = false;

			InitializeComponent();
			m_parent = parent;
			m_openedFile = fileDef;
			m_openedFile.m_frame = this;
			TextBox tb = new TextBox();
			RichTextBox rtb = new RichTextBox();

			if (System.IO.File.Exists(m_parent.m_filePath))
			{
				Run run = new Run();

				try
				{
					FileStream aFile = new FileStream(m_parent.m_filePath, FileMode.Open);
					StreamReader reader = new StreamReader(aFile, Encoding.Default);

					run.Text = reader.ReadToEnd();
					mx_textPara.Inlines.Add(run);
					reader.Close();
				}
				catch (IOException ex)
				{
					Public.ResultLink.createResult("\r\n打开文件失败。(" + ex + ")", Public.ResultType.RT_ERROR);
				}
			}

			m_isCheckChange = true;
		}

		private void mx_rtbText_PreviewKeyDown(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.Tab && sender is RichTextBox)
			{
				RichTextBox rtb = (RichTextBox)sender;
				String tab = new String(' ', 4);
				TextPointer caretPosition = rtb.CaretPosition;
				TextRange a = new TextRange(rtb.Document.ContentStart, rtb.Document.ContentEnd);

				caretPosition.InsertTextInRun(tab);
				//base.CaretIndex = caretPosition + TabSize + 1;
				e.Handled = true;
			}
		}
		private void mx_rtbText_TextChanged(object sender, TextChangedEventArgs e)
		{
			bool stackLock;

			if (m_eventLock.isLock())
			{
				return;
			}
			else
			{
				m_eventLock.addLock(out stackLock);
			}

			if (sender is RichTextBox)
			{
				RichTextBox rtb = (RichTextBox)sender;
				if (m_isCheckChange == false)
				{
					Public.RichTextTools.refreshXmlTextTip(rtb, s_mapKeyWordsGroup);
				}
			}

			m_eventLock.delLock(ref stackLock);
		}
	}
}
